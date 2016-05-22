using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind.Models
{
    public class PlayerResultModel
    {
        public string Name { get; set; }
        public bool? Winner { get; set; }
        public List<GuessResultModel> GuessHistory { get; set; }
    }
}
