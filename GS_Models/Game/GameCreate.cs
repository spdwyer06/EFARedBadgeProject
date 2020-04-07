using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Models.Game
{
    public class GameCreate
    {
        public enum TypeOfPlatform { Playstation4, XboxOne, NintendoSwitch, PC }
        public enum TypeOfCategory { FPS, RPG, Sports }
        public enum TypeOfRating { E, T, M }

      
        public string GameTitle { get; set; }
        public TypeOfPlatform PlatformType { get; set; }
        public TypeOfCategory CategoryType { get; set; }
        public TypeOfRating RatingType { get; set; }
        public double Price { get; set; }
    }
}
