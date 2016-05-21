using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Mastermind.Models;

namespace Mastermind.Controllers
{
    public class MastermindController : ApiController
    {
        [HttpPost]
        public InitialGameUserData NewGame(string nickName)
        {
            // iniciar jogo
            return new InitialGameUserData();
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
