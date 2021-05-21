using MTI.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MTI.ViewModel;
using MTI.Helpers;

namespace MTI.Controllers
{
    [Authorize]
    public class Daily_attendanceController : Controller
    {
        private ApplicationDbContext _context;

        public Daily_attendanceController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: Daily_attendance
        public ActionResult Index()
        {
            var dailyattenance = _context.daily_Attendances.Include(x => x.AbsantDetails).ToList();
            //filter data
            return View(dailyattenance);
        }
        //Add
        public ActionResult dailyattendance()
        {
           return View();
        }
        public ActionResult Create(daily_attendance daily_Attendance)
        {
            if (!ModelState.IsValid) {
                return View("dailyAttendance", daily_Attendance);
            }
            foreach (var data in daily_Attendance.AbsantDetails)
            {
                if (data.Studname == null || data.Department == null)
                {
                    daily_Attendance.AbsantDetails.Remove(data);
                }
            }

            if (daily_Attendance.AbsantDetails.Count != daily_Attendance.AbsentNum)
            {
                ViewBag.ErrorMessage = ("ادخل بيانات الطلاب المتغيبين");
                return View("dailyattendance", daily_Attendance);
            }
            // Arabicdate arabicdate = new Arabicdate();

            //string date = DateTime.Now.ToLongDateString();
            //date= arabicdate.ConvertToArabicNumerals(date);

            daily_Attendance.Date = DateTime.Now;
            var x= daily_Attendance.Date.Value.Month.ToString(new CultureInfo("ar-SA"));
            
            _context.daily_Attendances.Add(daily_Attendance);
            _context.SaveChanges();
            return RedirectToAction("Index", "Daily_attendance");
        }

        public ActionResult AbsentDetails()
        {
            var vm = new daily_attendance() { };
            return View(vm);
        }

        //Delete
        /* public ActionResult AbsentDetails()
         {
             var vm = new daily_attendance() { };
             return View(vm);
         }*/
        public ActionResult Viewday(int id)
        {
            var spesificday = _context.daily_Attendances.Include(X=>X.AbsantDetails).SingleOrDefault(c => c.ID == id);
            AbsantDepart absantDepart = new AbsantDepart();

            if (spesificday == null)
            {
                return HttpNotFound();
            }
            for (int i = 0; i < spesificday.AbsantDetails.Count; i++)
            {
                if (spesificday.AbsantDetails[i].Department == "عيادة")
                {
                    absantDepart.clinic += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "أتيام")
                {
                    absantDepart.Atiam += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "مأمورية")
                {
                    absantDepart.Mission += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "نوبتجي")
                {
                    absantDepart.nabtchy += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "مكتب")
                {
                    absantDepart.office += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "مست خارجي")
                {
                    absantDepart.outingmst += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "تدريب خارجي")
                {
                    absantDepart.outtrainning += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "أجازة بتصريح")
                {
                    absantDepart.permititedleave += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "سجن")
                {
                    absantDepart.prison += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "خدمة")
                {
                    absantDepart.services += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "أجازة مرضية")
                {
                    absantDepart.Sickleave += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "أختبارات")
                {
                    absantDepart.Tests += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "تحت الملاحظة")
                {
                    absantDepart.Underobservation += 1;
                }
                if (spesificday.AbsantDetails[i].Department == "زيارة")
                {
                    absantDepart.visit += 1;
                }


            }
            
            var attendance = new DailyattendanceViewModel()
            {
                absantDepart = absantDepart,
                dailyattendance=spesificday
            };

            return View("ViewAttendanceDetails", attendance);
        }
    }
}