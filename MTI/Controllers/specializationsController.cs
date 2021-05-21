using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MTI.Models;

namespace MTI.Controllers
{
    public class specializationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: specializations
        public ActionResult Index()
        {
            return View(db.specializations.ToList());
        }

        // GET: specializations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialization specialization = db.specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // GET: specializations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: specializations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,specialty")] specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.specializations.Add(specialization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(specialization);
        }

        // GET: specializations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialization specialization = db.specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: specializations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,specialty")] specialization specialization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(specialization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(specialization);
        }

        // GET: specializations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            specialization specialization = db.specializations.Find(id);
            if (specialization == null)
            {
                return HttpNotFound();
            }
            return View(specialization);
        }

        // POST: specializations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            specialization specialization = db.specializations.Find(id);
            db.specializations.Remove(specialization);
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
