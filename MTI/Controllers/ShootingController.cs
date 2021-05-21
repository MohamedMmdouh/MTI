using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MTI.Helpers;

namespace MTI.Controllers
{
    [Authorize]
    public class ShootingController : Controller
    {

        private ApplicationDbContext _context;
        public ShootingController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Shooting
        public ActionResult Index()
        {
                var Shooting = _context.shootings.ToList();
                var students = _context.students.ToList();
            IEnumerable<Shootingcastmodel> inner = Shooting.Join(
                                       students,
                                       shoot => shoot.StudentID,
                                       Student => Student.ID,
                                       (shoot, Student) => new Shootingcastmodel
                                       {
                                           ID = shoot.ID,
                                           StudentID = Student.StudentNumber,
                                           Dateofshoot = shoot.Dateofshoot,
                                           Grade = shoot.Grade,
                                           numofbullet = shoot.numofbullet,
                                           numofsuccessshots = shoot.numofsuccessshots,
                                           ShootigErrors = shoot.ShootigErrors,
                                           Trainingname = shoot.Trainingname,
                                           weaponname = shoot.weaponname,
                                           isvisible = Student.IsVIsible,
                                           level = shoot.level,
                                           }).Where(stud => stud.isvisible == true);
                return View("Index", inner);
            
        }

        public ActionResult AddData()
        {
            return View();
        }

        public ActionResult AddShooting(Shooting shooting)
        {
            if (!ModelState.IsValid)
            {
                return View("AddData", shooting);
            }
            var checker = _context.students.Include(c=>c.Section).SingleOrDefault(x => x.StudentNumber == shooting.StudentID);
            if (checker == null)
            {
                ViewBag.ErrorMessage = " رقم الطالب غير مسجل";
                return View("AddData", shooting);
            }
            if (shooting.numofsuccessshots > shooting.numofbullet)
            {
                ViewBag.ErrorMessage = "عدد الاصابات الصحيحة غير صحيح";
                return View("AddData", shooting);
            }
            shooting.StudentID = checker.ID;
            shooting.level = checker.Section.Level;
            _context.shootings.Add(shooting);
            _context.SaveChanges();

            return RedirectToAction("index","students");
        }

        //update
        public ActionResult Editdata(Shooting shooting)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", shooting);
            }
            else
            {
                var data = _context.shootings.SingleOrDefault(c => c.ID == shooting.ID);
                if (data == null)
                    return HttpNotFound();
                data.numofbullet = shooting.numofbullet;
                data.numofsuccessshots = shooting.numofsuccessshots;
                data.ShootigErrors = shooting.ShootigErrors;
                data.Trainingname = shooting.Trainingname;
                data.weaponname = shooting.weaponname;
            }
            _context.SaveChanges();
            return RedirectToAction("index", "shooting");
        }

        [Authorize]
        public ActionResult Update(int id)
        {

            var data = _context.shootings.SingleOrDefault(c => c.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            else
                return View(data);
        }

    }
}