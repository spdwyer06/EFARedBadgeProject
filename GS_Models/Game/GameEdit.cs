using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_Data.Game;

namespace GS_Models.Game
{
    public class GameEdit
    {
        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public TypeOfPlatform PlatformType { get; set; }
        public TypeOfCategory CategoryType { get; set; }
        public TypeOfRating RatingType { get; set; }
        public double Price { get; set; }
    }
}
