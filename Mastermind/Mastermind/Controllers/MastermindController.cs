﻿using System.Collections.Generic;
using System.Web.Http;
using Mastermind.Models;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using System.Threading.Tasks;
using System.Linq;
using AutoMapper;

namespace Mastermind.Controllers
{
    public class MastermindController : ApiController
    {
        private readonly IGameAppService _gameAppService;
        private readonly IMapper _mapper;

        public MastermindController(IGameAppService gameAppService, IMapper mapper)
        {
            _gameAppService = gameAppService;
            _mapper = mapper;
        }

        [HttpPost]
        public GameResultModel NewGame([FromBody] NewGameModel model)
        {
            return _mapper.Map<Game, GameResultModel>(_gameAppService.Create(model.Nickname, model.NumberOfPlayers));
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
