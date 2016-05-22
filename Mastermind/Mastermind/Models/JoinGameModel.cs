using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class JoinGameModel
    {
        public Guid GameId { get; set; }
        public string Nickname { get; set; }
    }
}
