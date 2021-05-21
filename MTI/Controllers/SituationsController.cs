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
    public class SituationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Situations
        public ActionResult Index()
        {
            var situations = db.situations.Include(s => s.students);
            return View(situations.ToList());
        }

        // GET: Situations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situations situations = db.situations.Find(id);
            if (situations == null)
            {
                return HttpNotFound();
            }
            return View(situations);
        }
        [Authorize(Roles = "Adminstrator,Admin")]

        // GET: Situations/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.students, "ID", "StudentNumber");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Adminstrator,Admin")]

        public ActionResult Create([Bind(Include = "ID,StudentID,SituationType,Details,procedure,date")] Situations situations)
        {
            if (ModelState.IsValid)
            {
                db.situations.Add(situations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentID = new SelectList(db.students, "ID", "Qualification", situations.StudentID);
            return View(situations);
        }


        [Authorize(Roles = "Adminstrator,Admin")]
        // GET: Situations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situations situations = db.situations.Find(id);
            if (situations == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.students, "ID", "studentNumber", situations.StudentID);
            return View(situations);
        }

        // POST: Situations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Adminstrator,Admin")]
        public ActionResult Edit([Bind(Include = "ID,StudentID,SituationType,Details,procedure,date")] Situations situations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(situations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.students, "ID", "StudentNumber", situations.StudentID);
            return View(situations);
        }

        [Authorize(Roles = "Adminstrator,Admin")]

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Situations situations = db.situations.Find(id);
            if (situations == null)
            {
                return HttpNotFound();
            }
            return View(situations);
        }

        [Authorize(Roles = "Adminstrator,Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Situations situations = db.situations.Find(id);
            db.situations.Remove(situations);
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
