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

        [Required]
        public TypeOfPlatform PlatformType { get; set; }

        [Required]
        public TypeOfCategory CategoryType { get; set; }

        [Required]
        public TypeOfRating RatingType { get; set; }

        [Required]
        public string GameName { get; set; }


        public int NumberOfReviews
        {
            get
            {
                if (Reviews != null)
                    return Reviews.Count;

                return 0;
            }
        }

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
