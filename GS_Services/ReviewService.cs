using GS_Data;
using GS_Models.ReviewViewModels;
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

        public ReviewDetail GetReviewByID(int id)
        {
            var entity = _db.Reviews
                .Single(x => x.ReviewID == id);

            return new ReviewDetail
            {
                UserID = entity.UserID,
                GameTitle = entity.Game.GameTitle,
                ReviewRating = entity.ReviewRating,
                ReviewDescription = entity.ReviewDescription
            };
        }

        public bool UpdateReview(ReviewEdit model)
        {
            var entity = _db.Reviews
                .Single(x => x.ReviewID == model.ReviewID && x.UserID == _userID);

            entity.ReviewRating = model.ReviewRating;
            entity.ReviewDescription = model.ReviewDescription;

            return _db.SaveChanges() == 1;
        }

        public bool DeleteReview(int reviewID)
        {
            var entity = _db.Reviews
                .Single(x => x.ReviewID == reviewID && x.UserID == _userID);

            _db.Reviews.Remove(entity);

            return _db.SaveChanges() == 1;
        }
    }
}
