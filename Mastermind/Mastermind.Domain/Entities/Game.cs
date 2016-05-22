using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;

namespace Mastermind.Domain.Entities
{
    public class Game
    {
        public Game()
        {            
            this.Colors = ConfigurationManager.AppSettings["colors"].Split(',');
            this.SequenceLength = int.Parse(ConfigurationManager.AppSettings["sequenceLength"]);
            this.Players = new HashSet<Player>();
            this.Guesses = new HashSet<Guess>();
            this.Sequence = GenerateSecretSequence();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public int NumberOfPlayers { get; set; }

        [Required]
        public string Sequence { get; set; }

        [Required]
        public int Status { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }

        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Guess> Guesses { get; set; }


        [NotMapped]
        public string[] Colors { get; private set; } 

        [NotMapped]
        public int SequenceLength { get; private set; } 



        private string GenerateSecretSequence()
        {
            var colors = this.Colors;
            string sequence = string.Empty;
            Random randomNumbers = new Random();

            for (int i = 0; i < colors.Length; i++)
                sequence += colors[randomNumbers.Next(0, colors.Length - 1)];

            return sequence;
        }
    }
}
