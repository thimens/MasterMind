using System;

namespace Mastermind.Models
{
    public class GuessModel
    {
        public Guid GameId { get; set; }
        public Guid PlayerId { get; set; }
        public string Sequence { get; set; }
    }
}
