using Mastermind.Domain.Entities;
namespace Mastermind.Models
{
    public class InitialGameUserData
    {
        public string GameId { get; set; } 
        public Color[] AvailableColors { get; set; }
        public int PlayerId { get; set; }
        
    }
}