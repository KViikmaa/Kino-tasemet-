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
    public class KinoModelsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: KinoModels
        public ActionResult Index()
        {
            return View(db.KinoModels.ToList());
        }

        // GET: KinoModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KinoModels kinoModels = db.KinoModels.Find(id);
            if (kinoModels == null)
            {
                return HttpNotFound();
            }
            return View(kinoModels);
        }
        [Authorize(Roles = "Admins")]
        // GET: KinoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KinoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Film,Kestuvus,Saal,Algus")] KinoModels kinoModels)
        {
            if (ModelState.IsValid)
            {
                db.KinoModels.Add(kinoModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kinoModels);
        }
        [Authorize(Roles = "Admins")]
        // GET: KinoModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KinoModels kinoModels = db.KinoModels.Find(id);
            if (kinoModels == null)
            {
                return HttpNotFound();
            }
            return View(kinoModels);
        }

        // POST: KinoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Film,Kestuvus,Saal,Algus")] KinoModels kinoModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kinoModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kinoModels);
        }
        [Authorize(Roles = "Admins")]
        // GET: KinoModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KinoModels kinoModels = db.KinoModels.Find(id);
            if (kinoModels == null)
            {
                return HttpNotFound();
            }
            return View(kinoModels);
        }

        // POST: KinoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KinoModels kinoModels = db.KinoModels.Find(id);
            db.KinoModels.Remove(kinoModels);
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
