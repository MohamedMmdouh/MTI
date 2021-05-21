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
    public class AttendancesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attendances
        public ActionResult Index()
        {
            var attendence = db.attendence.Include(a => a.students);
            return View(attendence.ToList());
        }

        // GET: Attendances/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // GET: Attendances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Attendances/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,StudentID,Date,Clinic_type,underObservation_from,underObservation_to,hosptital_from,hosptital_to,Absant_from,Absant_to,lec_absant,recovery,Details,Totalminusgrade")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                var getid = db.students.SingleOrDefault(x => x.StudentNumber == attendance.StudentID);
                if (getid == null)
                    return View(attendance);
                attendance.StudentID = getid.ID;
                db.attendence.Add(attendance);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(attendance);
        }

        // GET: Attendances/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentID = new SelectList(db.students, "ID", "Qualification", attendance.StudentID);
            return View(attendance);
        }

        // POST: Attendances/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,StudentID,Date,Clinic_type,underObservation_from,underObservation_to,hosptital_from,hosptital_to,Absant_from,Absant_to,lec_absant,recovery,Details,Totalminusgrade")] Attendance attendance)
        {
            if (ModelState.IsValid)
            {
                db.Entry(attendance).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentID = new SelectList(db.students, "ID", "Qualification", attendance.StudentID);
            return View(attendance);
        }

        // GET: Attendances/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Attendance attendance = db.attendence.Find(id);
            if (attendance == null)
            {
                return HttpNotFound();
            }
            return View(attendance);
        }

        // POST: Attendances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Attendance attendance = db.attendence.Find(id);
            db.attendence.Remove(attendance);
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
