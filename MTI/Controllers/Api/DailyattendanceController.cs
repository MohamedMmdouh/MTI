using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MTI.ViewModel;
using MTI.Helpers;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using System.Data.Entity.Validation;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;


namespace MTI.Controllers.Api
{
    public class DailyattendanceController : ApiController
    {
        private ApplicationDbContext _context;

        public DailyattendanceController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Deletedailyattend(int id)
        {
            try
            {
                var dailyattend = _context.daily_Attendances.Include(x=>x.AbsantDetails).SingleOrDefault(c => c.ID == id);
                if (dailyattend == null)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);          
                _context.daily_Attendances.Remove(dailyattend);
                _context.SaveChanges();
                return Ok(dailyattend);
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
            }
            
        }
        [HttpGet]
        public IEnumerable<daily_attendance> GetDailyattendance()
        {
            return _context.daily_Attendances.ToList();

        }
        [HttpGet]
        public Boolean Ifdailtattendencerecoreded()
        {
            var dayofsaved = _context.daily_Attendances.OrderByDescending(c => c.Date).First();
            if (dayofsaved.Date.Value.Date == DateTime.Now.Date)
                return false;
            return true;

        }
    }
}
