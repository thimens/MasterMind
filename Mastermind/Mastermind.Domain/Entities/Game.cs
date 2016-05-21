using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            this.Sequence = GenerateSecretCombination(8);
        }

        public string Id { get; set; }
        public bool Mutiplayer { get; set; }
        public List<Color> Sequence { get; set; }


        private List<Color> GenerateSecretCombination(int colorCount)
        {
            Color[] colorTemp = new Color[colorCount];
            Random randomNumbers = new Random();
            for (int i = 0; i < colorCount; i++)
            {
                colorTemp[i] = (Color)randomNumbers.Next(0, 8);
            }

            return colorTemp.ToList();
        }
    }
}
