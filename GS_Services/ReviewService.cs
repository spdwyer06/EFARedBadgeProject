using GS_Data;
using GS_Models.Review;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();
        private readonly Guid _userID;

        public ReviewService() { }

        public ReviewService(Guid userID)
        {
            _userID = userID;
        }

        public IEnumerable<ReviewListItem> GetReviews()
        {
            var query = _db.Reviews
                .Select(x => new ReviewListItem
                {
                    ReviewID = x.ReviewID,
                    GameTitle = x.Game.GameTitle,
                    ReviewRating = x.ReviewRating,
                    ReviewDescription = x.ReviewDescription
                });

            return query.ToArray();
        }

        public bool CreateReview(ReviewCreate model)
        {
            var entity = new Review
            {
                UserID = _userID,
                GameID = model.GameID,
                ReviewRating = model.ReviewRating,
                ReviewDescription = model.ReviewDescription
            };

            _db.Reviews.Add(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
