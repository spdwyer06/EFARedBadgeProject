﻿using GS_Models.ReviewViewModels;
using GS_Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GameStash.Controllers
{
    public class ReviewController : Controller
    {
        // GET: Review
        public ActionResult Index()
        {
            var service = new ReviewService();
            var model = service.GetReviews();
            Guid userID;

            if (User.Identity.IsAuthenticated)
            {
                userID = Guid.Parse(User.Identity.GetUserId());
            }
            else
            {
                userID = Guid.Parse("00000000-0000-0000-0000-000000000000");
            }

            ViewData["userID"] = userID;
            return View(model);
        }

        // GET: Review/Create
        [Authorize]
        public ActionResult Create(int gameID)
        {
            ViewData["gameID"] = gameID;
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model, int gameID)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateReviewService();

            if (service.CreateReview(model, gameID))
            {
                TempData["SaveResult"] = "Review successfully created.";
                return RedirectToAction("Index", "Game");
            }

            ModelState.AddModelError("", "Review could not be created.");
            return View(model);
        }

        // GET: Review/Details/{id}
        public ActionResult Details(int id)
        {
            //var service = CreateReviewService();
            var service = new ReviewService();
            var model = service.GetReviewByID(id);
            Guid userID;

            if (User.Identity.IsAuthenticated)
            {
                userID = Guid.Parse(User.Identity.GetUserId());
            }
            else
            {
                userID = Guid.Parse("00000000-0000-0000-0000-000000000000");
            }

            ViewData["userID"] = userID;
            return View(model);
        }

        // GET: Review/Edit/{id}
        [Authorize]
        public ActionResult Edit(int id)
        {
            var service = CreateReviewService();
            var detail = service.GetReviewByID(id);
            var model = new ReviewEdit
            {
                ReviewID = detail.ReviewID,
                GameTitle = detail.GameTitle,
                ReviewRating = detail.ReviewRating,
                ReviewDescription = detail.ReviewDescription
            };

            if (service.ValidateUser(id) == true)
                return View(model);

            return View("ValidationFailed");
        }

        // POST: Review/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ReviewEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.ReviewID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateReviewService();

            if (service.UpdateReview(model))
            {
                TempData["SaveResult"] = "The review was succesfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The review could not be updated.");
            return View(model);
        }

        // GET: Review/Delete/{id}
        [Authorize]
        public ActionResult Delete(int id)
        {
            var service = CreateReviewService();
            var model = service.GetReviewByID(id);

            if (service.ValidateUser(id) == true)
                return View(model);

            return View("ValidationFailed");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteReview(int id)
        {
            var service = CreateReviewService();

            service.DeleteReview(id);

            TempData["SaveResult"] = "The selected review was deleted.";

            return RedirectToAction("Index");
        }

        private ReviewService CreateReviewService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService(userID);

            return service;
        }

        public ActionResult ReturnToGames()
        {
            return RedirectToAction("Index", "Game");
        }
    }
}