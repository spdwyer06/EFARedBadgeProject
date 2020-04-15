using GS_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.ReviewViewModels
{
    public class ReviewDetail
    {
        public int ReviewID { get; set; }

        //[Required, Display(Name = "Created By")]
        //public Guid UserID { get; set; }

        [Required, Display(Name = "Created By")]
        [MaxLength(20, ErrorMessage = "There are too many characters in this field.")]
        public string CreatorDisplayName { get; set; }

        [ForeignKey("Game")]
        [Display(Name = "Game Title")]
        public string GameTitle { get; set; }
        public virtual Game Game { get; set; }

        [Required, Display(Name = "Review Rating")]
        [Range(1, 5)]
        public int ReviewRating { get; set; }

        [Display(Name = "Description")]
        [MaxLength(8000, ErrorMessage = "There are too many characters in this field.")]
        public string ReviewDescription { get; set; }
    }
}
