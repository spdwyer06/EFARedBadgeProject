using GS_Models.PostReplyViewModels;
using GS_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStash.Controllers
{
    public class PostReplyController : Controller
    {
        //public ActionResult RedirectToPostRepliesIndex(int replyID)
        //{
        //    var service = new PostReplyService();
        //    var entity = service.GetReplyByID(replyID);
        //    int postID = entity.PostID;

        //    return RedirectToAction("PostRepliesIndex", new { postID });
        //}

        // GET: /PostReply/PostRepliesIndex
        public ActionResult PostRepliesIndex(int postID)
        {
            var service = new PostReplyService();
            var model = service.GetRepliesByPostID(postID);

            ViewData["postID"] = postID;

            return View(model);
        }

        //GET: /PostReply/GoBackToThread
        public ActionResult GoBackToThread(int postID)
        {
            var service = new PostService();
            var model = service.GetPostByID(postID);

            return RedirectToAction("ThreadPostsIndex", "Post", new { threadID = model.ThreadID });
        }

        //public ActionResult MyRepliesIndex()
        //{
        //    var userID = Guid.Parse(User.Identity.GetUserId());
        //    var service = new PostReplyService(userID);
        //    var model = service.GetMyReplies();

        //    return View(model);
        //}

        //// GET: /PostReply
        //public ActionResult Index()
        //{
        //    var userID = Guid.Parse(User.Identity.GetUserId());
        //    var service = new PostReplyService(userID);
        //    var model = service.GetAllReplies();

        //    return View(model);
        //}

        //GET: /PostReply/Create
        [Authorize]
        public ActionResult Create(int postID)
        {
            ViewData["postID"] = postID;

            return View();
        }

        // POST: /PostReply/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostReplyCreate model, int postID)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateReplyService();

            if (service.CreatePostReply(model, postID))
            {
                TempData["SaveResult"] = "Your reply was created.";
                return RedirectToAction("PostRepliesIndex", new { postID = postID });
            }

            ModelState.AddModelError("", "Reply could not be created.");
            return View(model);
        }

        // GET: /PostReply/Details/{id}
        public ActionResult Details(int replyID)
        {
            var service = CreateReplyService();
            var model = service.GetReplyByID(replyID);

            return View(model);
        }

        // GET: /PostReply/Edit/{id}
        [Authorize]
        public ActionResult Edit(int replyID)
        {
            var service = CreateReplyService();
            var detail = service.GetReplyByID(replyID);
            var model = new PostReplyEdit
            {
                ReplyID = detail.ReplyID,
                ReplyContent = detail.ReplyContent,
            };

            ViewData["postID"] = detail.PostID;

            if (service.ValidateUser(replyID) == true)
                return View(model);

            return View("ValidationFailed");

        }

        // POST: /PostReply/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int replyID, PostReplyEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.ReplyID != replyID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateReplyService();
            var detail = service.GetReplyByID(replyID);

            if (service.UpdateReply(model))
            {
                TempData["SaveResult"] = "Your reply was updated.";
                return RedirectToAction("PostRepliesIndex", new { postID = detail.PostID });
            }

            ModelState.AddModelError("", "Your reply could not be updated.");
            return View(model);
        }

        // GET: /PostReply/Delete/{id}
        [Authorize]
        public ActionResult Delete(int replyID)
        {
            var service = CreateReplyService();
            var model = service.GetReplyByID(replyID);

            if (service.ValidateUser(replyID) == true)
                return View(model);

            ViewData["postID"] = model.PostID;
            return View("ValidationFailed");
        }

        // POST: /PostReply/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReply(int replyID)
        {
            var service = CreateReplyService();
            var entity = service.GetReplyByID(replyID);

            service.DeleteReply(replyID);

            TempData["SaveResult"] = "Your reply was deleted.";

            return RedirectToAction("PostRepliesIndex", new { postID = entity.PostID });
        }



        private PostReplyService CreateReplyService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PostReplyService(userID);
            return service;
        }
    }
}