using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Data
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public Guid UserID { get; set; }

        [ForeignKey("Game")]
        public int GameID { get; set; }
        public virtual Game Game { get; set; }

        //public Guid UserID { get; set; }

        [Required]
        [Range(1, 5)]
        public int ReviewRating { get; set; }

        // Not required to make a review
        public string ReviewDescription { get; set; }
    }
}
