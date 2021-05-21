using MTI.Helpers;
using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MTI.Controllers
{
    [Authorize]
    public class RewardController : Controller
    {
        StudentsController studentsController;
        private ApplicationDbContext _context;
        public RewardController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Reward
        public ActionResult Removepunshiment()
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
                                           isvisible = Student.IsVIsible
                                       }).Where(stud => stud.isvisible == true);
            if (User.IsInRole("Viewer") || User.IsInRole("Moderater"))
                return View("RewarsViewonly", inner);
            else
                return View("Removepunshiment", inner);
        }


        
        public ActionResult Index()
        {
            var Rewardss = _context.Rewards.ToList();
            var students = _context.students.ToList();
            IEnumerable<rewardcastmodel> inner = Rewardss.Join(
                                       students,
                                       reward => reward.StudentID,
                                       Student => Student.ID,
                                       (reward, Student) => new rewardcastmodel
                                       {
                                           ID = reward.ID,
                                           StudentID = Student.StudentNumber,
                                           WhoApplyIt = reward.WhoApplyIt,
                                           Reward_reason = reward.Reward_reason,
                                           reward = reward.reward,
                                           plusGrades = reward.plusGrades,
                                           RewardDate = reward.RewardDate,
                                           isvisible = Student.IsVIsible
                                       }).Where(stud => stud.isvisible == true );
            if (User.IsInRole("Admin") || User.IsInRole("Adminstrator"))
                return View("Index", inner);
            else
                return View("RewardsViewonly", inner);

        }

    
        [Authorize(Roles = "Adminstrator,Admin")]
        public ActionResult AddReward()
        {
            return View();
        }

        [Authorize(Roles = "Adminstrator,Admin")]

        public ActionResult Add_Reward(MTI.Models.Reward rewardModel)
        {
            if (!ModelState.IsValid)
            {
                return View("AddReward", rewardModel);
            }
            var checker = _context.students.SingleOrDefault(x => x.StudentNumber == rewardModel.StudentID);
            if (checker == null)
            {
                ViewBag.ErrorMessage = " رقم الطالب غير مسجل";
                return View("AddData", rewardModel);
            }
            checker.behaviour = checker.behaviour + rewardModel.plusGrades;
            rewardModel.StudentID = checker.ID;
            _context.Rewards.Add(rewardModel);
            _context.SaveChanges();

            return RedirectToAction("index", "students");
        }


        public ActionResult Resivedata(List<String> values)
        {
            TempData["ID"] = values;

            return RedirectToAction("Addrewards", "Reward");
        }
        [Authorize(Roles = "Adminstrator,Admin")]

        public ActionResult AddRewards()
        {

            return View();
        }
        //add one Reward to list of students;
        public ActionResult AddRewardss(Reward rewardModel)
        {
            studentsController = new StudentsController();
            List<string> values = new List<string>();
            values = TempData["ID"] as List<string>;

            foreach (var x in values)
            {
                rewardModel.StudentID = Convert.ToInt32(x);
                //rewardModel.RewardDate = DateTime.Now;
                //ModelState.Remove("RewardDate");
                if (ModelState.IsValid)
                {
                    studentsController.changebehviourgrade(Convert.ToInt32(x), rewardModel.plusGrades, "asd");
                    _context.Rewards.Add(rewardModel);
                    _context.SaveChanges();
                    TempData["ids"] = "";
                }
                else
                {
                    return View("AddRewards", rewardModel);
                }
            }
            return RedirectToAction("index", "students");
        }

        [Authorize(Roles = "Admin,Adminstrator")]
        //update
        public ActionResult Editdata(Reward rewardmodel)
        {
            if (!ModelState.IsValid)
            {
                return View("Update", rewardmodel);
            }
            else
            {
                var data = _context.Rewards.SingleOrDefault(c => c.ID == rewardmodel.ID);
                if (data == null)
                    return HttpNotFound();
                data.reward = rewardmodel.reward;
                data.WhoApplyIt = rewardmodel.WhoApplyIt;
                data.Reward_reason = rewardmodel.Reward_reason;
                data.plusGrades = rewardmodel.plusGrades;
                data.RewardDate = rewardmodel.RewardDate;
                data.StudentID = data.StudentID;
            }
            _context.SaveChanges();
            return RedirectToAction("index", "Reward");
        }
        [Authorize(Roles = "Adminstrator,Admin")]
        public ActionResult Update(int id)
        {

            var data = _context.Rewards.SingleOrDefault(c => c.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            else
                return View(data);
        }

        
        [Authorize(Roles = "Adminstrator")]
        public ActionResult Remove(int id)
        {
            Reward reward=new Reward();
            var data = _context.punishments.SingleOrDefault(c => c.ID == id);
            if (data == null)
            {
                return HttpNotFound();
            }
            else
            {
               StudentsController studentsController = new StudentsController();
                var stud = _context.students.SingleOrDefault(x => x.StudentNumber == data.StudentID);
                //true = punshiment to be removed -- false = punshiment available 
                data.Status = true;
                reward.reward = "تم ازالة عقوبة / جزاء " + data.punshiment;
                reward.plusGrades = data.MinusGrades;
                reward.Reward_reason = "";
                reward.RewardDate = DateTime.Now;
                reward.StudentID = data.StudentID;
                reward.WhoApplyIt = "مدير المعهد الفني للقوات المسلحة";
                studentsController.changebehviourgrade(stud.ID, reward.plusGrades, "asd");
            }
                return View(data);
        }


    }
}