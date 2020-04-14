using GS_Data;
using GS_Models.PostViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_Services
{
    public class PostService
    {
        private readonly ApplicationDbContext _dbContext = new ApplicationDbContext();

        private readonly Guid _userID;

        public PostService() { }

        public PostService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePost(PostCreate model, int threadID)
        {
            var entity = new Post()
            {
                PostCreator = _userID,
                CreatorDisplayName = GetDisplayName(_userID),
                PostContent = model.PostContent,
                ThreadID = threadID,
                PostCreated = DateTimeOffset.Now
            };

            _dbContext.Posts.Add(entity);
            return _dbContext.SaveChanges() == 1;
        }

        public IEnumerable<PostListItem> GetAllPosts()
        {
            var query = _dbContext.Posts
                    .Select(x => new PostListItem
                    {
                        PostID = x.PostID,
                        ThreadID = x.ThreadID,
                        CreatorDisplayName = x.CreatorDisplayName,
                        PostCreated = x.PostCreated,
                        Replies = x.Replies
                    });

            return query.ToArray();
        }

        //public IEnumerable<PostListItem> GetMyPosts()
        //{
        //    var query = _dbContext.Posts
        //            .Where(x => x.PostCreator == _userID)
        //            .Select(x => new PostListItem
        //            {
        //                PostID = x.PostID,
        //                ThreadID = x.ThreadID,
        //                PostCreator = x.PostCreator,
        //                PostCreated = x.PostCreated,
        //                Replies = x.Replies
        //            });

        //    return query.ToArray();
        //}

        public IEnumerable<PostListItem> GetPostsByThreadID(int threadID)
        {
            var query = _dbContext.Posts
                .Where(x => x.ThreadID == threadID)
                 .Select(x => new PostListItem
                 {
                     PostID = x.PostID,
                     ThreadID = x.ThreadID,
                     PostContent = x.PostContent,
                     CreatorDisplayName = x.CreatorDisplayName,
                     PostCreated = x.PostCreated,
                     Replies = x.Replies
                 });

            return query.ToArray();
        }

        public PostDetail GetPostByID(int postID)
        {
            var entity = _dbContext.Posts
                .Single(x => x.PostID == postID);

            return new PostDetail
            {
                PostID = entity.PostID,
                ThreadID = entity.ThreadID,
                CreatorDisplayName = entity.CreatorDisplayName,
                PostContent = entity.PostContent,
                PostCreated = entity.PostCreated,
                Replies = entity.Replies
            };
        }

        public bool UpdatePost(PostEdit model)
        {
            var entity = _dbContext.Posts
                .Single(x => x.PostID == model.PostID);

            entity.PostContent = model.PostContent;

            // May add in future
            //entity.ModifiedUtc = DateTimeOffset.UtcNow;

            return _dbContext.SaveChanges() == 1;
        }

        public bool DeletePost(int postID)
        {
            var entity = _dbContext.Posts
                // Grabs the Post with the matching given postID & will delete if the user is the post creator OR if the user is the thread creator
                .Single(x => x.PostID == postID);

            _dbContext.Posts.Remove(entity);

            return _dbContext.SaveChanges() == 1;

        }


        public bool ValidateUser(int postID)
        {
            var entity = _dbContext.Posts
                .Single(x => x.PostID == postID);

            if (entity.PostCreator == _userID || entity.Thread.ThreadCreator == _userID)
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
