using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Domain.Services
{
    public class GuessService : ServiceBase<Guess>, IGuessService
    {
        public GuessService(IRepositoryBase<Guess> repository) : base(repository) { }

        /// <summary>
        /// Return all guesses of a game
        /// </summary>
        /// <param name="gameId"></param>
        /// <returns>List of guesses</returns>
        public Task<IEnumerable<Guess>> GetAllByGame(Guid gameId)
        {
            return _repository.GetAsync(g => g.GameId == gameId);
        }
    }
}
