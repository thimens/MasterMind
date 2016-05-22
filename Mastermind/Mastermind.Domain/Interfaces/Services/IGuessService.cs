using Mastermind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Domain.Interfaces.Services
{
    public interface IGuessService : IServiceBase<Guess>
    {
        Task<IEnumerable<Guess>> GetAllByGame(Guid gameId);
    }
}
