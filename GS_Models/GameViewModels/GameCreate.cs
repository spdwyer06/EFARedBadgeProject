using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_Data.Game;

namespace GS_Models.GameViewModels
{
    public class GameCreate
    {
        [Required, Display(Name = "Title")]
        [MaxLength(100, ErrorMessage = "There are too many characters in this field.")]
        public string GameTitle { get; set; }

        [Required, Display(Name = "Platform")]
        public TypeOfPlatform PlatformType { get; set; }

        [Required, Display(Name = "Genre")]
        public TypeOfCategory CategoryType { get; set; }

        [Required, Display(Name = "Maturity Rating")]
        public TypeOfRating RatingType { get; set; }
        
        [Required, DataType(DataType.Currency)]
        public double Price { get; set; }
    }
}
