using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kino_tasemetöö.Models;

namespace Kino_tasemetöö.Controllers
{
    public class PiletsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pilets
        public ActionResult Index()
        {
            return View(db.Pilets.ToList());
        }

        // GET: Pilets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilet pilet = db.Pilets.Find(id);
            if (pilet == null)
            {
                return HttpNotFound();
            }
            return View(pilet);
        }
        
        // GET: Pilets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pilets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PiletiNr")] Pilet pilet)
        {
            if (ModelState.IsValid)
            {
                db.Pilets.Add(pilet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pilet);
        }

        // GET: Pilets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilet pilet = db.Pilets.Find(id);
            if (pilet == null)
            {
                return HttpNotFound();
            }
            return View(pilet);
        }

        // POST: Pilets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PiletiNr")] Pilet pilet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pilet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pilet);
        }
        // Loon uue actioni mis annab kasutajale pileti
        public ActionResult Osta(int id)
        {
            KinoModels Film  = db.KinoModels.Find(id);
            Pilet pilet = new Pilet();
            pilet.Film = Film;
                db.Pilets.Add(pilet);
                db.SaveChanges();
                return RedirectToAction("Index");
        
        }
        // GET: Pilets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pilet pilet = db.Pilets.Find(id);
            if (pilet == null)
            {
                return HttpNotFound();
            }
            return View(pilet);
        }

        // POST: Pilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pilet pilet = db.Pilets.Find(id);
            db.Pilets.Remove(pilet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
