using System.Collections.Generic;
using System.Web.Http;
using Mastermind.Models;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using Mastermind.Models;
using System;
using System.Threading.Tasks;

namespace Mastermind.Controllers
{
    public class MastermindController : ApiController
    {
        private readonly IGameAppService _gameAppService;

        public MastermindController(IGameAppService gameAppService)
        {
            _gameAppService = gameAppService;
        }
        [HttpPost]
        public Game NewGame([FromBody] NewGameModel model)
        {
            return _gameAppService.Create(model.Nickname, model.NumberOfPlayers);
            // iniciar jogo
            //return new InitialGameUserData();
        }

        [HttpPost]
        public async Task<Game> JoinGame([FromBody] JoinGameModel model)
        {
            return await _gameAppService.Join(model.Nickname, model.GameId);
            // Verificar:
            //   - gameId existe?
            //   - Jogo está em andamento?
            //   - Jogo já possui 2 jogadores?
            //
            // Se tudo ok, incluir este usuário no jogo
            //return new InitialGameUserData();
        }

        [HttpPost]
        public async Task<Game> Guess([FromBody] GuessModel model)
        {
            return await _gameAppService.Guess(model.PlayerId, model.GameId, model.Sequence);
        }

        [HttpGet]
        public async Task<IEnumerable<Game>> GamesAvailable()
        {
            return await _gameAppService.GetWaitingGames();
        }
    }
}
