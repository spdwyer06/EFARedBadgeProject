using GS_Services;
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
    }
}