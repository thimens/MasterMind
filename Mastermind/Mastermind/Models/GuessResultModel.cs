using System.Collections.Generic;

namespace Mastermind.Models
{
    public class GuessResultModel
    {
        public int NearCount { get; set; }
        public int ExactCount { get; set; }
        public string Sequence { get; set; }
    }
}