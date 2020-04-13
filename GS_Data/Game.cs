using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Data
{
    public class Game
    {
        public enum TypeOfPlatform { Playstation4, XboxOne, NintendoSwitch, PC }
        public enum TypeOfCategory { FPS, RPG, Sports }
        public enum TypeOfRating { E, T, M }

        [Key]
        public int GameID { get; set; }

        // Rename to UserID
        [Required]
        public Guid OwnerId { get; set; }

        [Required, Display(Name = "Platform")]
        public TypeOfPlatform PlatformType { get; set; }

        // Rename to GenreType
        [Required, Display(Name = "Genre")]
        public TypeOfCategory CategoryType { get; set; }

        [Required, Display(Name = "Maturity Rating")]
        public TypeOfRating RatingType { get; set; }

        [Required, Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string GameTitle { get; set; }

        [Required, DataType(DataType.Currency)]
        public double Price { get; set; }

        [Display(Name = "Number of Reviews")]
        public int NumberOfReviews
        {
            get
            {
                if (Reviews != null)
                    return Reviews.Count;

                return 0;
            }
        }

        [Display(Name = "Average Review Rating")]
        public double AverageReview
        {
            get
            {
                if (Reviews != null && Reviews.Count != 0)
                    return (double)Reviews.Sum(rating => rating.ReviewRating) / Reviews.Count;

                return 0;
            }
        }

        public virtual ICollection<Review>  Reviews { get; set; }
    }
}
