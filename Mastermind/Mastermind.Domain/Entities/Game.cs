using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Domain.Entities
{
    public class Game
    {
        public string Id { get; set; }
        public bool Mutiplayer { get; set; }
        public List<Color> Sequence { get; set; }
    }
}
