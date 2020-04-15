using GS_Data;
using GS_Models.GameViewModels;
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

        public GameService() { }

        public GameService(Guid userID)
        {
            _userID = userID;
        }

        public IEnumerable<GameListItem> GetGames()
        {
            var query = _db.Games
                .Select(x => new GameListItem
                {
                    GameID = x.GameID,
                    GameTitle = x.GameTitle,
                    PlatformType = x.PlatformType,
                    CategoryType = x.CategoryType,
                    RatingType = x.RatingType,
                    Price = x.Price,
                    Reviews = x.Reviews
                });

            return query.ToArray();
        }

        public bool CreateGame(GameCreate model)
        {
            var entity = new Game()
            {
                OwnerId = _userID,
                GameTitle = model.GameTitle,
                PlatformType = model.PlatformType,
                CategoryType = model.CategoryType,
                RatingType = model.RatingType,
                Price = model.Price
            };

            _db.Games.Add(entity);
            return _db.SaveChanges() == 1;
        }

        public GameDetail GetGameByID(int id)
        {
            var entity = _db.Games
                .Single(x => x.GameID == id);

            return new GameDetail
            {
                GameID = entity.GameID,
                GameTitle = entity.GameTitle,
                PlatformType = entity.PlatformType,
                CategoryType = entity.CategoryType,
                RatingType = entity.RatingType,
                Reviews = entity.Reviews,
                Price = entity.Price
            };
        }

        public bool UpdateGame(GameEdit model)
        {
            var entity = _db.Games
                .Single(x => x.GameID == model.GameID);

            entity.GameTitle = model.GameTitle;
            entity.PlatformType = model.PlatformType;
            entity.CategoryType = model.CategoryType;
            entity.RatingType = model.RatingType;
            entity.Price = model.Price;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteGame(int id)
        {
            var entity = _db.Games
                .Single(x => x.GameID == id);

            _db.Games.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
