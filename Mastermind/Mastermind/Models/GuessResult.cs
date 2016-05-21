using System.Collections.Generic;

namespace Mastermind.Models
{
    public class GuessResult
    {
        public string GameId { get; set; }
        public int PlayerId { get; set; }
        public int NearCount { get; set; }
        public int ExactCount { get; set; }
        public List<string> GuessHistory { get; set; }
    }
}