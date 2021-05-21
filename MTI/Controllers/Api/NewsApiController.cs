using MTI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MTI.Controllers.Api
{
    public class NewsApiController : ApiController
    {
        private ApplicationDbContext _context;

        public NewsApiController()
        {
            _context = new ApplicationDbContext();
        }
        //http://newsapi.org/v2/top-headlines?country=us&apiKey=9af209a1a84a46e187376e870a804704
        public IHttpActionResult GetNews() {
            DateTime ruleData = DateTime.Now.Date;
            var news = _context.news.Where(x => DbFunctions.TruncateTime(x.Date) == ruleData).ToList();
            if (news.Count == 0)
            {      
                 news = _context.news.Where(x => x.category== "سياسة").ToList();
                return Ok(news);
            }

            return Ok(news);
        }
    }
}
