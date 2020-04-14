using GS_Data;
using GS_Models.PostReplyViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Services
{
    public class PostReplyService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        private readonly Guid _userID;

        public PostReplyService() { }

        public PostReplyService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePostReply(PostReplyCreate model, int postID)
        {
            var entity = new PostReply()
            {
                ReplyCreator = _userID,
                CreatorDisplayName = GetDisplayName(_userID),
                ReplyContent = model.ReplyContent,
                PostID = postID,
                ReplyCreated = DateTimeOffset.Now
            };

            _dbContext.Replies.Add(entity);
            return _dbContext.SaveChanges() == 1;
        }

        //public IEnumerable<PostReplyListItem> GetMyReplies()
        //{
        //    var query = _dbContext.Replies
        //            .Where(x => x.ReplyCreator == _userID)
        //            .Select(x => new PostReplyListItem
        //            {
        //                ReplyID = x.ReplyID,
        //                PostID = x.PostID,
        //                ReplyCreator = x.ReplyCreator,
        //                ReplyCreated = x.ReplyCreated
        //            });

        //    return query.ToArray();
        //}

        public IEnumerable<PostReplyListItem> GetRepliesByPostID(int postID)
        {
            var query = _dbContext.Replies
                .Where(x => x.PostID == postID)
                 .Select(x => new PostReplyListItem
                 {
                     ReplyID = x.ReplyID,
                     PostID = x.PostID,
                     ReplyContent = x.ReplyContent,
                     CreatorDisplayName = x.CreatorDisplayName,
                     ReplyCreated = x.ReplyCreated,
                 });

            return query.ToArray();
        }

        public IEnumerable<PostReplyListItem> GetAllReplies()
        {
            var query = _dbContext.Replies
                    .Select(x => new PostReplyListItem
                    {
                        ReplyID = x.ReplyID,
                        PostID = x.PostID,
                        CreatorDisplayName = x.CreatorDisplayName,
                        ReplyCreated = x.ReplyCreated
                    });

            return query.ToArray();
        }

        public PostReplyDetail GetReplyByID(int replyID)
        {
            var entity = _dbContext.Replies
                .Single(x => x.ReplyID == replyID); 

            return new PostReplyDetail
            {
                ReplyID = entity.ReplyID,
                PostID = entity.PostID,
                CreatorDisplayName = entity.CreatorDisplayName,
                ReplyContent = entity.ReplyContent,
                ReplyCreated = entity.ReplyCreated,
            };
        }

        public bool UpdateReply(PostReplyEdit model)
        {
            var entity = _dbContext.Replies
                .Single(x => x.ReplyID == model.ReplyID); 

            entity.ReplyContent = model.ReplyContent;
            // May add in future
            //entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _dbContext.SaveChanges() == 1;
        }

        public bool DeleteReply(int replyID)
        {
            var entity = _dbContext.Replies
                .Single(x => x.ReplyID == replyID); 

            _dbContext.Replies.Remove(entity);

            return _dbContext.SaveChanges() == 1;
        }


        public bool ValidateUser(int replyID)
        {
            var entity = _dbContext.Replies
                .Single(x => x.ReplyID == replyID);

            if (entity.ReplyCreator == _userID || entity.Post.PostCreator == _userID || entity.Post.Thread.ThreadCreator == _userID)
                return true;

            return false;
        }

        public string GetDisplayName(Guid userID)
        {
            var user = _dbContext.Users
                .Where(x => x.Id == userID.ToString())
                .Single();

            var displayName = user.DisplayName;

            return displayName;
        }
    }
}
