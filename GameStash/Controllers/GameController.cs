using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GS_Data;
using GS_Models.Game;
using GS_Services;
using Microsoft.AspNet.Identity;

namespace GameStash.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Game
        public ActionResult Index()
        {
            var service = new GameService();
            var model = service.GetGames();

            return View(model);
        }

        // GET: Game/Create
        // User must be logged in to create a game
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Game could not be created.");
            return View(model);
        }

        // GET: Game/Details/{id}
        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameByID(id);

            return View(model);
        }

        // GET: Game/Edit/{id}
        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var detail = service.GetGameByID(id);
            var model = new GameEdit
            {
                GameID = detail.GameID,
                GameTitle = detail.GameTitle,
                PlatformType = detail.PlatformType,
                CategoryType = detail.CategoryType,
                RatingType = detail.RatingType,
                Price = detail.Price
            };

            return View(model);
        }

        // POST: Game/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if(model.GameID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateGameService();

            if (service.UpdateGame(model))
            {
                TempData["SaveResult"] = "The game was successfully updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The game could not be updated.");
            return View(model);
        }

        // GET: Game/Delete/{id}
        public ActionResult Delete(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameByID(id);

            return View(model);
        }

        // POST: Game/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var service = CreateGameService();

            service.DeleteGame(id);

            TempData["SaveResult"] = "Selected game deleted.";

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }

        private GameService CreateGameService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userID);
            return service;
        }
    }
}
