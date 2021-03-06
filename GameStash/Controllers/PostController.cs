﻿using GS_Models.PostViewModels;
using GS_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStash.Controllers
{
    public class PostController : Controller
    {
        //GET: /Post/GoToRepliesForPost
        public ActionResult GoToRepliesForPost(int postID)
        {
            return RedirectToAction("PostRepliesIndex", "PostReply", new { postID });
        }

        //public ActionResult MyRepliesIndex()
        //{
        //    var userID = Guid.Parse(User.Identity.GetUserId());
        //    var service = new PostReplyService(userID);
        //    service.GetReplies();

        //    return RedirectToAction("MyRepliesIndex", "PostReply");
        //}

        //GET: /Post/ThreadPostsIndex
        public ActionResult ThreadPostsIndex(int threadID)
        {
            var service = new PostService();
            var model = service.GetPostsByThreadID(threadID);
            var newService = new ThreadService();
            var parent = newService.GetThreadByID(threadID);
            var threadTitle = parent.ThreadTitle;

            ViewData["threadTitle"] = threadTitle;
            ViewData["threadID"] = threadID;
            return View(model);
        }

        // Takes the PostEdit model's postID and returns it as a PostDetail model to retrieve the associated ThreadID
        //public ActionResult RedirectToThreadPostsIndex(int postID)
        //{
        //    var service = new PostService();
        //    var entity = service.GetPostByID(postID);
        //    int threadID = entity.ThreadID;

        //    return RedirectToAction("ThreadPostsIndex", "Post", new { threadID = threadID });
        //}

        ////GET: /Post/AllPostsIndex
        //public ActionResult AllPostsIndex()
        //{
        //    var userID = Guid.Parse(User.Identity.GetUserId());
        //    var service = new PostService(userID);
        //    var model = service.GetAllPosts();

        //    return View(model);
        //}

        //GET: /Post/Create
        [Authorize]
        public ActionResult Create(int threadID)
        {
            var newService = new ThreadService();
            var parent = newService.GetThreadByID(threadID);
            var threadTitle = parent.ThreadTitle;

            ViewData["threadTitle"] = threadTitle;
            ViewData["threadID"] = threadID;
            return View();
        }

        // POST: /Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PostCreate model, int threadID)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreatePostService();

            if (service.CreatePost(model, threadID))
            {
                TempData["SaveResult"] = "Your post was created.";
                return RedirectToAction("ThreadPostsIndex", "Post", new { threadID });
            }

            ModelState.AddModelError("", "Post could not be created.");
            return View(model);
        }

        // GET: /Post/Details/{id}
        public ActionResult Details(int postID)
        {
            //var service = CreatePostService();
            var service = new PostService();
            var model = service.GetPostByID(postID);

            return View(model);
        }

        // GET: /Post/Edit/{id}
        [Authorize]
        public ActionResult Edit(int postID)
        {
            var service = CreatePostService();
            var detail = service.GetPostByID(postID);
            var model = new PostEdit
            {
                PostID = detail.PostID,
                PostContent = detail.PostContent,
            };

            ViewData["threadID"] = detail.ThreadID;

            if (service.ValidateUser(postID) == true)
                return View(model);

            return View("ValidationFailed");
        }

        // POST: /Post/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int postID, PostEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.PostID != postID)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreatePostService();
            var detail = service.GetPostByID(postID);

            if (service.UpdatePost(model))
            {
                TempData["SaveResult"] = "Your post was updated.";
                return RedirectToAction("ThreadPostsIndex", new { threadID = detail.ThreadID });
            }

            ModelState.AddModelError("", "Your post could not be updated.");
            return View(model);
        }

        // GET: /Post/Delete/{id}
        [Authorize]
        public ActionResult Delete(int postID)
        {
            var service = CreatePostService();
            var model = service.GetPostByID(postID);

            if (service.ValidateUser(postID) == true)
                return View(model);

            ViewData["threadID"] = model.ThreadID;
            return View("ValidationFailed");
        }

        // POST: /Post/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int postID)
        {
            var service = CreatePostService();
            var entity = service.GetPostByID(postID);

            service.DeletePost(postID);

            TempData["SaveResult"] = "Your post was deleted.";
            return RedirectToAction("ThreadPostsIndex", new { threadID = entity.ThreadID });
        }



        private PostService CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new PostService(userID);
            return service;
        }
    }
}