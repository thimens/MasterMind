using Mastermind.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Application.Interfaces
{
    public interface IGameAppService
    {
        Game Create(string playerName, int numberOfPlayers);
        Game Join(string playerName, string gameId);
        Task<IEnumerable<Game>> GetWaitingGames();
        Game Guess(string playerId, string gameId, string sequence);
    }
}
