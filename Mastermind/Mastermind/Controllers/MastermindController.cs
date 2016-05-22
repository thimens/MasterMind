using System.Collections.Generic;
using System.Web.Http;
using Mastermind.Models;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using Mastermind.ViewModels;

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
        public InitialGameUserData JoinGame(string nickName, string gameId)
        {
            // Verificar:
            //   - gameId existe?
            //   - Jogo está em andamento?
            //   - Jogo já possui 2 jogadores?
            //
            // Se tudo ok, incluir este usuário no jogo
            return new InitialGameUserData();
        }

        [HttpPost]
        public GuessResult Guess(string[] colorGuess, string nickName, string gameId)
        {
            return new GuessResult();
        }

        [HttpGet]
        public List<string> GamesAvailable()
        {
            return new List<string>();
        }
    }
}
