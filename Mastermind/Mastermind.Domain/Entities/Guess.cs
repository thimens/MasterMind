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
    }
}
