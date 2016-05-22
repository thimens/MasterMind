using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Mastermind.Domain.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        public GameService(IRepositoryBase<Game> repository) : base(repository) { }

        /// <summary>
        /// Return a list of games that are waiting players to join to. Only games that are open for less than 10 min are returned
        /// </summary>
        /// <returns>List of games</returns>
        public Task<IEnumerable<Game>> GetWaitingGames()
        {
            return _repository.GetAsync(g => g.NumberOfPlayers > 1 && g.Status == 0 && g.CreationDate >= DbFunctions.AddMinutes(DateTime.Now, -10), null, g => g.Players, g => g.Guesses);
        }
    }

}

