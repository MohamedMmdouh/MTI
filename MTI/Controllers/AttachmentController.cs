using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTI.Controllers
{
    public class AttachmentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Attachment
        public ActionResult Index()
        {
            var data = db.attachment.ToList();
            IEnumerable<Attachments> attachments = data;
            return View("index", attachments);
        }

        // GET: Attachment/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Attachment/Create
        public ActionResult Create()
        {
            ViewBag.StudentID = new SelectList(db.students, "ID", "StudentNumber");
            return View();
        }

        // POST: Attachment/Create
        [HttpPost]
        public ActionResult Create(Attachments attachments)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View("Create", attachments);

                db.attachment.Add(attachments);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public Boolean creation(Attachments attachments)
        {
            if (!ModelState.IsValid)
                return false;

            db.attachment.Add(attachments);
            db.SaveChanges();
            return true;
        }

        // GET: Attachment/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Attachment/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Attachment/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Attachment/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
