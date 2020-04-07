using GS_Data;
using GS_Models.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static GS_Data.Game;

namespace GS_Services
{
    public class GameService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userID;

        public GameService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {

                GameTitle = model.GameTitle,
                PlatformType = (TypeOfPlatform)model.PlatformType,
                CategoryType = (TypeOfCategory)model.CategoryType,
                RatingType = (TypeOfRating)model.RatingType,
                Price = model.Price
            };

            _db.Games.Add(entity);
            return _db.SaveChanges() == 1;
        }
    }
}
