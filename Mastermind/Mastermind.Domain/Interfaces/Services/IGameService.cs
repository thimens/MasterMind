using Mastermind.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Domain.Services;

namespace Mastermind.Domain.Interfaces.Services
{
    public interface IGameService : IServiceBase<Game>
    {
        Color[] GenerateSecretCombination();

        Hits CheckHits(Color[] guess, Color[] secretCombination);
    }
}
