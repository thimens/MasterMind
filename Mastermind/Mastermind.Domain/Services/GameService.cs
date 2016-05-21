using Mastermind.Domain.Entities;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Domain.Services
{
    public class GameService : ServiceBase<Game>, IGameService
    {
        private short ColorCount = 8;

        public GameService(IRepositoryBase<Game> repository) : base(repository)
        {
        }

        public Color[] GenerateSecretCombination()
        {
            Color[] colorTemp = new Color[ColorCount];
            Random randomNumbers = new Random();
            for (int i = 0; i < ColorCount; i++)
            {
                colorTemp[i] = (Color)randomNumbers.Next(0, 8);
            }

            return colorTemp;
        }

        public Hits CheckHits(Color[] guess, Color[] secretCombination)
        {
            var near = 0;
            var exact = 0;

            Color[] found = new Color[0];

            for (int i = 0; i < ColorCount; i++)
            {
                if (secretCombination.Any(x => x == guess[i]))
                {
                    if (!found.Any(x => x == guess[i]))
                    {
                        near++;
                        Array.Resize(ref found, near);
                        found[near - 1] = guess[i];
                    }
                }

                if (secretCombination[i] == guess[i])
                {
                    if (found.Any(x => x == guess[i]) && near > 0)
                        near--;
                    exact++;
                }
            }

            return new Hits() {ExactCount = exact, NearCount = exact};
        }

       
    }

}

