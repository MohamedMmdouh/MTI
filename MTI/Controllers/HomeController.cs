using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace MTI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        IList<News>NewsList;

        public HomeController()
        {
            NewsList = db.news.ToList();
        }
        //    <add name="DefaultConnection" connectionString="Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-MTI-20200621082625.mdf;Initial Catalog=aspnet-MTI-20200621082625;Integrated Security=True" providerName="System.Data.SqlClient" />
        //        <add name="DefaultConnection" connectionString="Data Source=DESKTOP-A1SSQOF;AttachDbFilename=MTI;Initial Catalog=MTI;Integrated Security=True" providerName="System.Data.SqlClient" />



        [OutputCache(Duration =50,Location =System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index()
        {

            return View();
        }




        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult marquee()
        {
            var data = db.news.ToList();
            return PartialView(data);
        }



        public ActionResult CommingSoon()
        {
            return View();
        }
    }
}