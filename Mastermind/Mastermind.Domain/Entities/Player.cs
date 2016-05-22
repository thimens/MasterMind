using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mastermind.Domain.Entities
{
    public class Player
    {
        public Player()
        {
            this.Guesses = new HashSet<Guess>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public bool Winner { get; set; }

        [Required]
        public string GameId { get; set; }

        public virtual Game Game { get; set; }
        public ICollection<Guess> Guesses { get; set; }
    }
}
