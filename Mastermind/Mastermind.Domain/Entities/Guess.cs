using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Mastermind.Domain.Entities
{
    public class Guess
    {
        [Key]
        public int Id { get; set; }

        [Index("idx_gId_pId", 0)]
        public Guid GameId { get; set; }

        [Index("idx_gId_pId", 1)]
        public Guid PlayerId { get; set; }

        [Required]
        [MaxLength(15)]
        public string Sequence { get; set; }

        [Required]
        public int NearCount { get; set; }

        [Required]
        public int ExactCount { get; set; }

        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }


        public void CheckHits(string secretCombination)
        {
            var near = 0;
            var exact = 0;

            var colorsCount = secretCombination.GroupBy(x => x)
                .Select(group => new
                {
                    id = group.Key,
                    Count = group.Count()
                });

            var guessColorsCount = Sequence.GroupBy(x => x)
                .Select(group => new
                {
                    id = group.Key,
                    Count = group.Count()
                });

            foreach (var guessColor in guessColorsCount)
            {
                var colorFound = colorsCount.FirstOrDefault(c => c.id == guessColor.id);
                if (colorFound != null)
                {
                    if (colorFound.Count <= guessColor.Count)
                    {
                        near += colorFound.Count;
                    }
                    else
                    {
                        near += guessColor.Count;
                    }
                }
            }


            for (int i = 0; i < secretCombination.Length; i++)
            {
                if (secretCombination[i] == this.Sequence[i])
                {
                    if (near > 0) near--;
                    exact++;
                }
            }

            this.ExactCount = exact;
            this.NearCount = near;
        }
    }
}
