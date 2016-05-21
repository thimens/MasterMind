using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Domain.Entities
{
    public class Guess
    {
        public string GameId { get; set; }
        public string UserId { get; set; }
        public List<Color> Sequence { get; set; }
        public int NearCount { get; set; }
        public int ExactCount { get; set; }


        public void CheckHits(Color[] secretCombination)
        {
            var near = 0;
            var exact = 0;

            Color[] found = new Color[0];

            for (int i = 0; i < secretCombination.Count(); i++)
            {
                if (secretCombination.Any(x => x == Sequence[i]))
                {
                    if (!found.Any(x => x == Sequence[i]))
                    {
                        near++;
                        Array.Resize(ref found, near);
                        found[near - 1] = Sequence[i];
                    }
                }

                if (secretCombination[i] == Sequence[i])
                {
                    if (found.Any(x => x == Sequence[i]) && near > 0)
                        near--;
                    exact++;
                }
            }

            this.ExactCount = exact;
            this.NearCount = near;
        }
    }
}
