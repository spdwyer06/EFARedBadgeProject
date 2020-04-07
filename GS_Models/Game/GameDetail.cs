using GS_Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_Data.Game;

namespace GS_Models.Game
{
    public class GameDetail
    {
        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public TypeOfPlatform PlatformType { get; set; }
        public TypeOfCategory CategoryType { get; set; }
        public TypeOfRating RatingType { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
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

        public virtual ICollection<GS_Data.Review> Reviews { get; set; }
    }
}
