using System.Collections.Generic;
using System.Web.Http;
using Mastermind.Models;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Entities;
using System.Threading.Tasks;
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
        public async Task<GameResultModel> JoinGame([FromBody] JoinGameModel model)
        {
            return _mapper.Map<Game, GameResultModel>(await _gameAppService.Join(model.Nickname, model.GameId));
        }

        [HttpPost]
        public async Task<GameResultModel> Guess([FromBody] GuessModel model)
        {
            return _mapper.Map<Game, GameResultModel>(await _gameAppService.Guess(model.PlayerId, model.GameId, model.Sequence));
        }

        [HttpGet]
        public async Task<IEnumerable<GameResultModel>> GamesAvailable()
        {
            return _mapper.Map<IEnumerable<Game>, IEnumerable<GameResultModel>>(await _gameAppService.GetWaitingGames());
        }
    }
}
