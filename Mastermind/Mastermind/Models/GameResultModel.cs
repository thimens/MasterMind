using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class GameResultModel
    {
        public string GameId { get; set; }
        public int PlayerId { get; set; }
        public int NumberOfPlayers { get; set; }
        public string Status { get; set; }
        public int Round { get; set; }
        public GuessResultModel Guess { get; set; }
    }
}
