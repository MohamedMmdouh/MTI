using MTI.Helpers;
using MTI.Models;
using MTI.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTI.Controllers
{
    public class RelativesController : Controller
    {
        public ApplicationDbContext _context;

        public RelativesController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Relatives
        public ActionResult Index()
        {
            return View();
        }

        // GET: Relatives/Details/5
        public ActionResult Relatives()
        {
            var relatives = _context.relatives.ToList();
            var students = _context.students.ToList();
            IEnumerable<Relativecastmodel> inner = relatives.Join(
                                       students,
                                       Relative => Relative.ID,
                                       Student => Student.ID,
                                       (Relative, Student) => new Relativecastmodel
                                       {
                                           ID = Relative.ID,
                                           StudentNumber = Student.StudentNumber,
                                           StudentNAme = Student.Name,
                                           isvisible = Student.IsVIsible,
                                           Job = Relative.Job,
                                           NumAmongBrothers = Relative.NumAmongBrothers,
                                           Numofbrothers = Relative.Numofbrothers,
                                           FatherNum = Relative.fatherNum,
                                           Relationship=Relative.Relationship,
                                           Relativename=Relative.Relativename,
                                           
                                       }).Where(stud => stud.isvisible == true);
            return View(inner);
        }

        // GET: Relatives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Relatives/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Relatives/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Relatives/Edit/5
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

        // GET: Relatives/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Relatives/Delete/5
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
        [HttpGet]
        public ActionResult MessageCenter()
        {

            var students = _context.students
                          .Select(x => new StudnetNum
                          {
                              ID = x.ID,
                              Name=x.Name,
                              Studentnum=x.StudentNumber,
                              phone_number=x.Mobile
                            })
                           .ToList();


            if (students == null)
                return View();
            else
                return View(students);
        }
    }
}
