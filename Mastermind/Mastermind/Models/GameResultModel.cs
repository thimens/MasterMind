using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class GameResultModel
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public int NumberOfPlayers { get; set; }
        public string Status { get; set; }
        public int Round { get; set; }
        public string[] Colors { get; set; }
        public int SequenceLength { get; set; }
        public GuessResultModel Guess { get; set; }
        public List<PlayerResultModel> Players { get; set; }
    }
}
