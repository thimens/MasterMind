using System.Collections.Generic;

namespace Mastermind.Models
{
    public class PlayerResultModel
    {
        public string Name { get; set; }
        public bool? Winner { get; set; }
        public List<GuessResultModel> GuessHistory { get; set; }
    }
}
