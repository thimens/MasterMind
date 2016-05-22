using Mastermind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Application.Interfaces
{
    public interface IGameAppService
    {
        Game Create(string playerName, int numberOfPlayers);
        Task<Game> Join(string playerName, Guid gameId);
        Task<IEnumerable<Game>> GetWaitingGames();
        Task<Game> Guess(Guid playerId, Guid gameId, string sequence);
    }
}
