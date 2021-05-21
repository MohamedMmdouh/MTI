using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MTI.ViewModel;
using System.Data.Entity.Validation;
using System.IO;
using MTI.Helpers.Img;
using System.Data;
using System.Reflection;
using MTI.Helpers;
using MTI.Customdata;


namespace MTI.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        List<string> BloodType = new List<string> { "A", "A+", "A-", "AB", "AB+", "AB-", "B-", "B+", "B", "O", "O+", "O-" };
        private ApplicationDbContext _context;

        public StudentsController()
        {
            _context = new ApplicationDbContext();
        }


        public List<dynamic> GetListFromDT(Type className, DataTable dataTable)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (DataRow row in dataTable.Rows)
            {
                object objClass = Activator.CreateInstance(className);
                Type type = objClass.GetType();
                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = type.GetProperty(column.ColumnName);
                    prop.SetValue(objClass, row[column.ColumnName], null);
                }
                list.Add(objClass);
            }
            return list;
        }

        public ActionResult data()
        {
            var students = _context.students.Include(c => c.specialization).Include(c => c.shootings).Include(c => c.batch).Include(x => x.relative).ToList();
            return View(students);
        }

        // GET: Students 
        //View only
        public ActionResult Index()
        {
            var Students = _context.students.Include(c=>c.Section).Include(c=>c.specialization).Include(c=>c.shootings).Include(c=>c.batch).Include(c=>c.relative).ToList();
            if (User.IsInRole("Admin")|| User.IsInRole("Adminstrator"))
                return View("Index", Students);
            else
                return View("Readonlystudent", Students);
        }

        //Add
        public ActionResult New()
        {       
            var specializations = _context.specializations.ToList();
            var sections = _context.sections.ToList();
            var batch = _context.batch.ToList();
            var relative = _context.relatives.ToList();
            var Studentviewmodel = new StudentViewModel
            {
                specialization = specializations,
                sections = sections,
                batches = batch,
                BloodType = BloodType
            };
            return View(Studentviewmodel);
        }

        public ActionResult createStudent()
        {
            var specializations = _context.specializations.ToList();
            var sections = _context.sections.ToList();
            var batch = _context.batch.ToList();
            var relative = _context.relatives.ToList();
            var studentdata = new ViewModelStudent
            {
                specialization = specializations,
                sections = sections,
                batches = batch,
                BloodType = BloodType
            };
            return View(studentdata);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(StudentViewModel student) {
            Image image = new Image();
            var viewmodel = new StudentViewModel
            {
                sections = _context.sections.ToList(),
                specialization = _context.specializations.ToList(),
                students = student.students,
                batches = _context.batch.ToList(),
                BloodType = BloodType,
            };
            ModelState.Remove("students.ID");

            if (!ModelState.IsValid)
            {
                return View("New", viewmodel);
            }
            //new student insert
            if (student.students.ID == 0)
            {
                if (_context.students.Where(x => x.StudentNumber == student.students.StudentNumber).Any())
                {
                    ViewBag.ErrorMessage = "هذا الرقم العسكري مسجل من قبل";
                    return View("New", viewmodel);
                }
                if (_context.students.Where(x => x.SSN == student.students.SSN).Any())
                {
                    ViewBag.ErrorMessage = "الرقم القومي مسجل مسبقا";
                    return View("New", viewmodel);
                }

                if (image.insertimage(student))
                {

                    student.students.IsVIsible = true;
                    _context.students.Add(student.students);
                    _context.SaveChanges();

                }
                else
                {
                    ViewBag.ErrorMessage = "اختر صوره بصيغه صحيحه";
                    return View("New", viewmodel);
                }
            }
            //update 
            else
            {
                var studentindb = _context.students.Single(x => x.ID == student.students.ID);
                var Relativeindb = _context.relatives.Single(x => x.ID == student.students.ID);
                var qualificationindb = _context.qualifications.Single(x => x.ID == student.students.ID);
                var bodyindb = _context.bodydetails.Single(x => x.ID == student.students.ID);

                studentindb.Name = student.students.Name;
                studentindb.StudentNumber = student.students.StudentNumber;
                studentindb.batchid = student.students.batchid;
                studentindb.getindate = student.students.getindate;
                studentindb.grade = student.students.grade;
                studentindb.joindate = student.students.joindate;
                studentindb.Fasila = student.students.Fasila;
                studentindb.saria = student.students.saria;
                studentindb.Katiba = student.students.Katiba;
                studentindb.group = student.students.group;
                studentindb.PlaceofBirth = student.students.PlaceofBirth;
                studentindb.cityofbirth = student.students.cityofbirth;
                studentindb.City = student.students.City;
                studentindb.Post = student.students.Post;
                studentindb.SpecializationID = student.students.SpecializationID;
                studentindb.SectionID = student.students.SectionID;
                studentindb.Religion = student.students.Religion;
                studentindb.Nationality = student.students.Nationality;
                studentindb.SSN = student.students.SSN;
                studentindb.Mobile = student.students.Mobile;
                studentindb.secondNum = student.students.secondNum;
                studentindb.Blood_Type = student.students.Blood_Type;
                studentindb.BirthDate = student.students.BirthDate;
                studentindb.Address = student.students.Address;
                studentindb.Email = student.students.Email.ToString();

                Relativeindb.fathername = student.students.relative.fathername;
                Relativeindb.fatherNum = student.students.relative.fatherNum;
                Relativeindb.fatherJob = student.students.relative.fatherJob;
                Relativeindb.fatherqualification = student.students.relative.fatherqualification;
                Relativeindb.mothername = student.students.relative.mothername;
                Relativeindb.mothernum = student.students.relative.mothernum;
                Relativeindb.motherJob = student.students.relative.motherJob;
                Relativeindb.motherqualification = student.students.relative.motherqualification;
                Relativeindb.Responsable = student.students.relative.Responsable;
                Relativeindb.ResponsableNum = student.students.relative.ResponsableNum;
                Relativeindb.ResponsableJob = student.students.relative.ResponsableJob;
                Relativeindb.Address = student.students.relative.Address;
                Relativeindb.Relativename = student.students.relative.ResponsableJob;
                Relativeindb.Relativeaddress = student.students.relative.Relativeaddress;
                Relativeindb.Relativenum = student.students.relative.Relativenum;
                Relativeindb.JobAddress = student.students.relative.JobAddress;
                Relativeindb.Relationship = student.students.relative.Relationship;
                Relativeindb.Job = student.students.relative.Job;
                Relativeindb.NumAmongBrothers = student.students.relative.NumAmongBrothers;
                Relativeindb.Numofbrothers = student.students.relative.Numofbrothers;
                Relativeindb.TotalSalary = student.students.relative.TotalSalary;

                qualificationindb.Qualification = student.students.qualifications.Qualification;
                qualificationindb.qualispecialize = student.students.qualifications.qualispecialize;
                qualificationindb.qualidepart = student.students.qualifications.qualidepart;
                qualificationindb.qualigetdate = student.students.qualifications.qualigetdate;
                qualificationindb.gpa = student.students.qualifications.gpa;

                bodyindb.weight = student.students.Bodydetails.weight;
                bodyindb.height = student.students.Bodydetails.height;
                bodyindb.bodysymmetry = student.students.Bodydetails.bodysymmetry;

                if (student.students.ImageFile != null)
                {
                    if (image.insertimage(student))
                    {
                        //Remove old img and insert new
                        var filePath = studentindb.Image;                    
                        System.IO.File.Delete(Server.MapPath(filePath));            
                        studentindb.Image = student.students.Image;
                    }                    
                    else
                        return View("New", viewmodel);
                }
               
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index","Students");
            
        }


        public string changebehviourgrade(int id,float grade,string operation) {

            var student = _context.students.Include(s=>s.Section).SingleOrDefault(x => x.ID == id);
            if (student == null)
                return null;
            else
            {
                if(operation=="minus")
                student.behaviour = student.behaviour - grade;
                else
                    student.behaviour = student.behaviour + grade;
            }
            _context.SaveChanges();
            var xx= student.Section.Level.ToString();
            return student.Section.Level.ToString();
        }

        //Edit
        [Authorize(Roles = "Admin,Adminstrator")]
        public ActionResult Edit(int ID)
        {
            
            var Student =
              
                _context.students.SingleOrDefault(c => c.ID == ID);
            if (Student == null)
                return HttpNotFound();

            var studentviewmodel = new StudentViewModel
            {
                students = Student,
                specialization = _context.specializations.ToList(),
                sections = _context.sections.ToList(),
                batches = _context.batch.ToList(),
                BloodType = BloodType
            };

            return View("New",studentviewmodel);
        }

        //Delete
        public ActionResult Delete(int ID)
        {
            var Student = _context.students.SingleOrDefault(c => c.ID == ID);
            if (Student == null)
                return HttpNotFound();
            Student.IsVIsible = false;
            _context.SaveChanges();
            return View();
        }

        public ActionResult ViewStudent(int id)
        {
            var student = _context.students.Include(c=>c.specialization).Include(c=>c.Section).Include(c=>c.shootings).Include(c=>c.Rewards).Include(c => c.punishments).Include(c => c.batch).SingleOrDefault(c => c.ID == id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View("Viewstudent", student);
        }
        public ActionResult studentbehaviour()
        {
            return View();
        }
        
        public StudentsArabicdata convertdataAr(Students students)
        {
            StudentsArabicdata student_Ar = new StudentsArabicdata();
            var student = students;

            student_Ar.ID = student.ID.ToString();
            student_Ar.grade = student.grade.ToString();

            student_Ar.StudentNumber = Arabicdate.ConvertNumeralsToArabic(student.StudentNumber.ToString());
            student_Ar.SSN = Arabicdate.ConvertNumeralsToArabic(student.SSN);

            student_Ar.BirthDate = (Arabicdate.ConvertNumeralsToArabic(student.BirthDate.Value.Date.ToString("yyyy/MM/dd")));
            student_Ar.getindate = (Arabicdate.ConvertNumeralsToArabic(student.getindate.Value.Date.ToString("yyyy/MM/dd")));
            student_Ar.Joindate = (Arabicdate.ConvertNumeralsToArabic(student.joindate.Value.Date.ToString("yyyy/MM/dd")));
            if (student.graduatedate != null)
                student_Ar.graduatedate = (Arabicdate.ConvertNumeralsToArabic(student.graduatedate.Value.Date.ToString("yyyy/MM/dd")));
            student_Ar.Mobile = Arabicdate.ConvertNumeralsToArabic(student.Mobile);
            student_Ar.secondNum = Arabicdate.ConvertNumeralsToArabic(student.secondNum);
            student_Ar.fatherNum = Arabicdate.ConvertNumeralsToArabic(student.relative.fatherNum);
            student_Ar.batchNo = Arabicdate.ConvertNumeralsToArabic(student.batch.batchNo.ToString());
            // student_Ar.GPA = Arabicdate.ConvertNumeralsToArabic(student.GPA.ToString());
            student_Ar.Numofbrothers = Arabicdate.ConvertNumeralsToArabic(student.relative.Numofbrothers.ToString());
            student_Ar.NumAmongBrothers = Arabicdate.ConvertNumeralsToArabic(student.relative.NumAmongBrothers.ToString());
            student_Ar.Name = student.Name;
            student_Ar.Email = student.Email;
            student_Ar.Level = student.Section.Level;
            student_Ar.Specialization = student.specialization.specialty;
            student_Ar.Katiba = Arabicdate.ConvertNumeralsToArabic(student.Katiba);
            student_Ar.saria = Arabicdate.ConvertNumeralsToArabic(student.saria);
            student_Ar.Fasila = Arabicdate.ConvertNumeralsToArabic(student.Fasila);
            student_Ar.gama3a = Arabicdate.ConvertNumeralsToArabic(student.group);
            student_Ar.Qualification = student.qualifications.Qualification;
            student_Ar.PlaceofBirth = student.PlaceofBirth;
            student_Ar.cityofbirth = student.cityofbirth;
            student_Ar.Nationality = student.Nationality;
            student_Ar.generalspecialize = student.main_specialization;
            student_Ar.City = student.City;
            student_Ar.Religion = student.Religion;
            student_Ar.Post = student.Post;
            student_Ar.behaviour = Arabicdate.ConvertNumeralsToArabic(student.behaviour.ToString());

                student_Ar.Weight = Arabicdate.ConvertNumeralsToArabic(student.Bodydetails.weight.ToString());
            student_Ar.height = Arabicdate.ConvertNumeralsToArabic(student.Bodydetails.height.ToString());
            student_Ar.bodysymetry = Arabicdate.ConvertNumeralsToArabic(student.Bodydetails.bodysymmetry.ToString());

            student_Ar.Qualification = student.qualifications.Qualification;
            student_Ar.GPA = Arabicdate.ConvertNumeralsToArabic(student.qualifications.gpa.ToString());
            student_Ar.Qualificationdepart = student.qualifications.qualidepart;
            student_Ar.Qualificationspecialize = student.qualifications.qualispecialize.ToString();
            student_Ar.qualificationgetdate = Arabicdate.ConvertNumeralsToArabic(student.qualifications.qualigetdate.ToString());

            student_Ar.Address = student.Address;
            student_Ar.Blood_Type = student.Blood_Type;
            student_Ar.Job = student.relative.Job;
            student_Ar.wepon = student.armyspecialization;

            student_Ar.fathername = student.relative.fathername;
            student_Ar.fatherjob = student.relative.fatherJob;
            student_Ar.fatherqualifcation = student.relative.fatherqualification;
            student_Ar.fatherNum = Arabicdate.ConvertNumeralsToArabic(student.relative.fatherNum.ToString());

            student_Ar.mothername = student.relative.mothername;
            student_Ar.motherjob = student.relative.motherJob;
            student_Ar.motherqualifcation = student.relative.motherqualification;
            student_Ar.motherNum = Arabicdate.ConvertNumeralsToArabic(student.relative.mothernum.ToString());

            student_Ar.responsiblename = student.relative.Responsable;
            student_Ar.responsibleNum = Arabicdate.ConvertNumeralsToArabic(student.relative.ResponsableNum.ToString());
            student_Ar.responsiblejob = student.relative.ResponsableJob;

            student_Ar.Relativename = student.relative.Relativename;
            student_Ar.Relativeadress = student.relative.Relativeaddress;
            student_Ar.RelativeNum = Arabicdate.ConvertNumeralsToArabic(student.relative.Relativenum.ToString());
            student_Ar.Relationship = student.relative.Relationship;
            student_Ar.Job = student.relative.Job;
            student_Ar.Jobaddress = student.relative.JobAddress;
            student_Ar.Address = student.relative.Address   ;


            student_Ar.totalsalary = Arabicdate.ConvertNumeralsToArabic(student.relative.TotalSalary.ToString());

            student_Ar.Relationship = student.relative.Relationship;
            student_Ar.punishments = student.punishments;
            student_Ar.shootings = student.shootings;
            student_Ar.situations = student.situations;
            student_Ar.Image = student.Image;
           
            student_Ar.Rewards = student.Rewards;
            student_Ar.attendances = student.attendances;


            return student_Ar;
        }

        public ActionResult StudentCard(int ID)
        {
            StudentsArabicdata student_Ar = new StudentsArabicdata();
            var student = _context.students.Include(c => c.specialization).Include(c => c.Section).Include(c => c.shootings).Include(c => c.Rewards).Include(c => c.punishments).Include(c => c.batch).Include(c=>c.situations).Include(c=>c.attendances).SingleOrDefault(c => c.ID == ID);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = Arabicdate.ConvertNumeralsToArabic("التاريخ : " + DateTime.Now.Date.Year+"/" + DateTime.Now.Date.Month+"/" + DateTime.Now.Date.Day);
            student_Ar= convertdataAr(student);
            return View("StudentCard", student_Ar);
        }

        public ActionResult StudentMainInfo(int ID)
        {
            var student = _context.students.Include(c => c.specialization).Include(c => c.Section).Include(c => c.shootings).Include(c => c.Rewards).Include(c => c.punishments).Include(c => c.batch).Include(c => c.situations).SingleOrDefault(c => c.ID == ID);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.Date = Arabicdate.ConvertNumeralsToArabic("التاريخ : " + DateTime.Now.Date.Day + "/" + DateTime.Now.Date.Month + "/" + DateTime.Now.Date.Year);
            StudentsArabicdata student_Ar = convertdataAr(student);
            return View("StudentMainInfo", student_Ar);
        }

        public ActionResult wasikatT3arf(int ID)
        {
            var stud = _context.students.Include(c => c.specialization).Include(c => c.Section).Include(c => c.shootings).Include(c => c.Rewards).Include(c => c.punishments).Include(c => c.batch).Include(c => c.situations).SingleOrDefault(c => c.ID == ID);
            if (stud == null)
                return HttpNotFound();
            ViewBag.Date = Arabicdate.ConvertNumeralsToArabic("التاريخ : " + DateTime.Now.Date.ToString("yyyy /MM/dd"));
            StudentsArabicdata student_Ar = convertdataAr(stud);
            return View("wasikatT3arf", student_Ar);
        }

            public ActionResult ControlPanael()
        {
            return View();
        }
    }
}