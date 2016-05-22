using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Services;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Application
{
    public class GameAppService : IGameAppService
    {
        private readonly IDbContextScopeFactory _dbContextFactory;
        private readonly IGameService _gameService;
        private readonly IGuessService _guessService;

        public GameAppService(IDbContextScopeFactory dbContextFactory, IGameService gameService, IGuessService guessService) //: base(dbContextFactory, gameService)
        {
            _dbContextFactory = dbContextFactory;
            _gameService = gameService;
            _guessService = guessService;
        }

        public Game Create(string playerName, int numberOfPlayers)
        {
            using (IDbContextScope contextScope = _dbContextFactory.Create())
            {
                //create player
                var player = new Player() { Name = playerName };

                //create game
                var game = new Game() { NumberOfPlayers = numberOfPlayers, Status = numberOfPlayers > 1 ? 0 : 1 };

                //add player to game
                game.Players.Add(player);

                //add game and player to database
                _gameService.Add(game);
                contextScope.SaveChanges();

                game.PlayerId = player.Id;

                return game;
            }            
        }

        public async Task<IEnumerable<Game>> GetWaitingGames()
        {
            using (IDbContextReadOnlyScope contextScope = _dbContextFactory.CreateReadOnly())
            {
                return await _gameService.GetWaitingGames();
            }
        }

        public async Task<Game> Guess(Guid playerId, Guid gameId, string sequence)
        {
            using (IDbContextScope contextScope = _dbContextFactory.Create())
            {
                var game = await _gameService.GetAsync(gameId);

                //check if game exists
                if (game == null)
                    throw new ApplicationException("Invalid game");

                //check if player belongs to the game
                if (!game.Players.Any(p => p.Id == playerId))
                    throw new ApplicationException("Player dont belong to this game");

                var playerGuesses = game.Players.First(p => p.Id == playerId).Guesses;

                if (game.Guesses.Count() > 0)
                {
                    //check if there are players that didnt play
                    if (game.Players.Select(p => p.Guesses.Count).Min() < playerGuesses.Count())
                        throw new ApplicationException("Wait for other players guess");

                    //check if the game is finished
                    if (game.Players.Select(p => p.Guesses.Count).Min() == game.Players.Select(p => p.Guesses.Count).Max() && game.Status == 2)
                        throw new ApplicationException("Game is finished");
                }

                var guess = new Guess()
                {
                    GameId = gameId,
                    PlayerId = playerId,
                    Sequence = sequence
                };

                //check the guess hits
                guess.CheckHits(game.Sequence);

                //if the player founds the sequence, change game status
                if (guess.ExactCount == game.SequenceLength)
                {
                    game.Status = 2;
                    game.Players.First(p => p.Id == playerId).Winner = true;
                }

                //add guess to game
                game.Guesses.Add(guess);

                game.PlayerId = playerId;

                _gameService.Update(game);
                contextScope.SaveChanges();

                return game;
            }
        }

        public async Task<Game> Join(string playerName, Guid gameId)
        {
            using (IDbContextScope contextScope = _dbContextFactory.Create())
            {
                var game = await _gameService.GetAsync(gameId);

                //check if game exists
                if (game == null)
                    throw new ApplicationException("Invalid game");

                //check status and number of players allowed
                if (game.NumberOfPlayers == 1 || game.Status != 0)
                    throw new ApplicationException("This game is not available for new players");
                
                //add player to game
                var player = new Player() { Name = playerName, GameId = gameId };
                game.Players.Add(player);

                //if game reach the number of player, change game status
                if (game.NumberOfPlayers == game.Players.Count)
                    game.Status = 1;

                //update database
                _gameService.Update(game);
                contextScope.SaveChanges();

                game.PlayerId = player.Id;

                return game;
            }
        }
    }
}
