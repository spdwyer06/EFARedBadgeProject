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

namespace GameStash.Controllers
{
    public class GameController : Controller
    {
        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Game
        public ActionResult Index()
        {
            return View(_db.Games.ToList());
        }

        // GET: Game/Create
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

            //var service = CreateGameService();

            var service = new GameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Note could not be created.");
            return View(model);

            //if (ModelState.IsValid)
            //{
            //    _db.Games.Add(game);
            //    _db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(game);
        }

        // GET: Game/Details/{id}
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // GET: Game/Edit/{id}
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameID,PlatformType,CategoryType,RatingType,GameTitle,Price")] Game game)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(game).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(game);
        }

        // GET: Game/Delete/{id}
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = _db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Game/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = _db.Games.Find(id);
            _db.Games.Remove(game);
            _db.SaveChanges();
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
    }
}
