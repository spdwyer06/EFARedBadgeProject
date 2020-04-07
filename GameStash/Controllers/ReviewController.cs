using GS_Models.Review;
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

            return View(model);
        }

        // GET: Review/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ReviewCreate model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var service = CreateReviewService();

            if (service.CreateReview(model))
            {
                TempData["SaveResult"] = "Review successfully created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Review could not be created.");
            return View(model);
        }



        private ReviewService CreateReviewService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new ReviewService();

            return service;
        }
    }
}