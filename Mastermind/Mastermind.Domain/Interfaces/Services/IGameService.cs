using Mastermind.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase<Game>
    {
        Task<IEnumerable<Game>> GetWaitingGames();

        //Color[] GenerateSecretCombination();

        //Hits CheckHits(Color[] guess, Color[] secretCombination);
    }
}
