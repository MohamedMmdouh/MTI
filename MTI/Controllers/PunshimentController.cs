using MTI.Helpers;
using MTI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Security;
using System.Data.Entity;

namespace MTI.Controllers
{
    [Authorize]
    public class PunshimentController : Controller
    {
        StudentsController studentsController;

        private ApplicationDbContext _context;
        public PunshimentController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Punshiment
        public ActionResult Index()
        {
            //ICollection<punishment> punishments = new Collection<punishment>();
            var punishmentss = _context.punishments.ToList();
            var students = _context.students.ToList();
            IEnumerable<punshimentcastmodel> inner = punishmentss.Join(
                                       students,
                                       Punshiment => Punshiment.StudentID,
                                       Student => Student.ID,
                                       (Punshiment, Student) => new punshimentcastmodel
                                       {
                                           ID = Punshiment.ID,
                                           StudentID = Student.StudentNumber,
                                           WhoApplyIt = Punshiment.WhoApplyIt,
                                           crime = Punshiment.crime,
                                           level = Punshiment.level,
                                           punshiment = Punshiment.punshiment,
                                           MinusGrades = Punshiment.MinusGrades,
                                           PunshimentDate = Punshiment.PunshimentDate,
                                           isvisible = Student.IsVIsible,
                                           status = Punshiment.Status
                                       }).Where(stud=>stud.isvisible ==true);
            if(User.IsInRole("Viewer")||User.IsInRole("Moderater"))
            return View("punshimentsReadonly", inner);
            else
              return View("Index", inner);
        }


        public ActionResult AddPunshiment()
        {
            return View();
        }


        [Authorize(Roles  = "Adminstrator,Admin")]
        public ActionResult Add_Punshiment(punishment punishment)
        {
           // punishment.PunshimentDate = DateTime.Now;
            //ModelState.Remove("PunshimentDate");

            if (!ModelState.IsValid)
            {
                return View("AddPunshiment", punishment);
            }
            var checker = _context.students.Include(s=>s.Section).SingleOrDefault(x => x.StudentNumber == punishment.StudentID);
            if (checker == null)
            {
                ViewBag.ErrorMessage = " رقم الطالب غير مسجل";
                return View("AddPunshiment", punishment);
            }
            checker.behaviour=checker.behaviour-punishment.MinusGrades;
            punishment.StudentID = checker.ID;
            punishment.Status = false;
            punishment.level = checker.Section.Level;
            _context.punishments.Add(punishment);
            _context.SaveChanges();

            return RedirectToAction("studentcard/" + checker.ID, "students");
        }

        [Authorize(Roles = "Adminstrator,Admin")]
        public ActionResult EditPunshiment(int id)
        {
            var checker = _context.punishments.SingleOrDefault(c => c.ID == id);
            if (checker == null)
            {
                return HttpNotFound();
            }
            else
                return View("AddPunshiment","punshiment" ,checker);
        }

        [Authorize(Roles = "Admin,Adminstrator")]
        public ActionResult Editdata(punishment punishment)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", punishment);
            }
            else
            {
                var data = _context.punishments.SingleOrDefault(c => c.ID == punishment.ID);
                if (data == null)
                    return HttpNotFound();

                //behaviour update
                var checker = _context.students.Include(s => s.Section).SingleOrDefault(x => x.StudentNumber == punishment.StudentID);
                checker.behaviour = checker.behaviour -(data.MinusGrades-punishment.MinusGrades);

                data.punshiment = punishment.punshiment;
                data.WhoApplyIt = punishment.WhoApplyIt;
                data.crime = punishment.crime;
                data.MinusGrades = punishment.MinusGrades;
                data.PunshimentDate = punishment.PunshimentDate;
                data.StudentID = data.StudentID;
                data.level = punishment.level;
            }
            _context.SaveChanges();
            return RedirectToAction("index", "Punshiment");
        }

        [Authorize(Roles = "Adminstrator,Admin")]
        public ActionResult Update(int id)
        {

            var data= _context.punishments.SingleOrDefault(c => c.ID == id);
            return View(data);
        }

        public ActionResult Resivedata(List<String> values)
        {
            TempData["ids"] = values;

            return RedirectToAction("Addpunshiments", "punshiment");
        }
        [Authorize(Roles = "Adminstrator,Admin")]

        public ActionResult Addpunshiments()
        {
           return View();
        }

        //add one punshiment to list of students;
        public ActionResult Addpunshimentss(punishment punishment)
        {
            studentsController = new StudentsController();
            List<string> values = new List<string>();
            values = TempData["ids"] as List<string>;
            foreach(var x in values)
            {
                punishment.StudentID = Convert.ToInt32(x);
                //punishment.PunshimentDate = DateTime.Now;
                //ModelState.Remove("PunshimentDate");
                if (ModelState.IsValid)
                {
                    var status=studentsController.changebehviourgrade(Convert.ToInt32(x), punishment.MinusGrades, "minus");
                    if (status != null) { 
                    punishment.level = status;
                     punishment.Status = false;
                     _context.punishments.Add(punishment);
                    _context.SaveChanges();
                    TempData["ids"] = "";
                    }
                    else
                    {
                        continue;
                    }
                }
                else
                {
                    return View("index","students");
                }
            }
            return RedirectToAction("index","punshiment");  
        }
    }
}