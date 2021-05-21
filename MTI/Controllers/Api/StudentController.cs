using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace MTI.Controllers.Api
{
    public class StudentController : ApiController
    {
        private ApplicationDbContext _context;
        
        public StudentController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult getStudents()
        {
            var student = _context.students.Where(c => c.IsVIsible == true).Include(c => c.Section).Include(c => c.specialization).Include(c => c.batch).Include(x => x.relative).ToList();
            if (student == null)
                return BadRequest();

            return Ok(student);
        }

        [HttpGet]
        public IHttpActionResult GetStudent(int id)
        {
            var student = _context.students.SingleOrDefault(c => c.ID == id);
            if (student == null)
                return BadRequest();

            return Ok(student);

        }

        [HttpPost]
        public IHttpActionResult studentnmberexist(int id)
        {
            var student = _context.students.SingleOrDefault(c => c.StudentNumber == id);
            if (student == null)
                return BadRequest();

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult CreateStudent(Students students)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.students.Add(students);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPut]
        public void updatestudent(int id, Students students)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var studentindb = _context.students.SingleOrDefault(c => c.ID == id);
            if (studentindb == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            studentindb.Name = students.Name;
            studentindb.StudentNumber = students.StudentNumber;
            studentindb.batchid = students.batchid;
            studentindb.getindate = students.getindate;
            //studentindb.GPA = students.GPA;
            studentindb.Qualification = students.Qualification;
            studentindb.Fasila = students.Fasila;
            studentindb.saria = students.saria;
            studentindb.Katiba = students.Katiba;
            studentindb.PlaceofBirth = students.PlaceofBirth;
            studentindb.City = students.City;
            studentindb.Post = students.Post;
            studentindb.SpecializationID = students.SpecializationID;
            studentindb.SectionID = students.SectionID;
            studentindb.Religion = students.Religion;
            studentindb.Nationality = students.Nationality;
            studentindb.SSN = students.SSN;
            studentindb.Mobile = students.Mobile;
            studentindb.secondNum = students.secondNum;
            studentindb.Blood_Type = students.Blood_Type;
            studentindb.BirthDate = students.BirthDate;
            studentindb.Address = students.Address;
            studentindb.Email = students.Email;
           studentindb.relative.Relativename = students.relative.Relativename;
            studentindb.relative.Relationship = students.relative.Relationship;
            studentindb.relative.Job = students.relative.Job;
            studentindb.relative.Numofbrothers = students.relative.Numofbrothers ;
            studentindb.relative.NumAmongBrothers = students.relative.NumAmongBrothers;
            

        }

        //[HttpDelete]
        [HttpPost]
        public IHttpActionResult DeleteStudent(int id)
        {
            try
            {
                var stud = _context.students.SingleOrDefault(c => c.ID == id);
                if (stud == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);
                stud.IsVIsible = false;
                _context.SaveChanges();
                return Ok();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }            //_context.students.Remove(stud);
        }

        //student with minus grades more than 20
        [HttpGet]
        public IEnumerable<Students> getbadstudnets()
        {
            return _context.students.Where(c => c.IsVIsible == true).Where(c => c.behaviour < -20).Include(c => c.Section).Include(c => c.specialization).Include(c => c.batch).ToList().OrderByDescending(c => c.batch.batchNo);
        }

        [HttpPost]
        public IHttpActionResult Deletestudentsdatabybatch(int studentid1, int studentid2)
        {
            _context.students.RemoveRange(_context.students.Where(x => x.StudentNumber >= studentid1 && x.StudentNumber <= studentid2));
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IHttpActionResult Restore(int id)
        {
            var student = _context.students.SingleOrDefault(c => c.ID == id);
            if (student == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            if (student.IsVIsible == false)
            {
                student.IsVIsible = true;
                _context.SaveChanges();
            }
            else
            {
                return BadRequest();
            }
            return Ok(student);
        }


    }
}
