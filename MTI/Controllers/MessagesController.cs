using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GsmComm.GsmCommunication;
using MTI.Helpers.Messages;
using MTI.Models;

namespace MTI.Controllers
{

    public class MessagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Messages
        public ActionResult Index()
        {
            return View(db.Messages.ToList());
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Message message)
        {
            message.Date = DateTime.Now;
            message.From = "01062344312";
            ModelState.Remove("Date");
            ModelState.Remove("From");
            if (ModelState.IsValid)
            {
                db.Messages.Add(message);
                db.SaveChanges();
                //Test Messages there
                
                SMS sms=new SMS();
                //  var x = db.students.Where(ss => ss.batch.batchNo == Convert.ToInt32(message.to)).Select(s => s.Mobile).ToList();
                sms.SendSMS("01062347267", "test");
                /*if (sms.SendSMS("01110440753", "test"))
                {
                   foreach (var data in x)
                    {
                        sms.SendSMS(data, "Hello THere");    
                    }
                }
                */


                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,From,to,MessageContent")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
