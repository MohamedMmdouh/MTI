using MTI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using MTI.Models;


namespace MTI.Controllers.Api
{
   
    public class PostController : ApiController
    {
        AttachmentController attachmentcontroller;
        private ApplicationDbContext _context;

        public PostController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: api/Post
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <upload image album for student attachments>
        /// upload images
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public String[] uploadfiles(int id)
        {
            System.Web.HttpFileCollection files = HttpContext.Current.Request.Files;
            var data = HttpContext.Current.Request.Form;
            Attachments attachments = new Attachments();
            attachments.StudentID  = Convert.ToInt32(data["id"]);
            attachments.Attachmenttype = data["atttype"];
            attachments.Organization = data["org"];

            var directoryInfo = new DirectoryInfo("~/Attachments");

            if (directoryInfo.Exists)
            {
                directoryInfo.CreateSubdirectory(id.ToString());
            }
         
            string[] Path = new string[files.Count];
            string Adddate = DateTime.Now.ToString("yyyy-MM-dd-HH-ss");
            for (var i = 0; i < files.Count; i++)
            {
                HttpPostedFile file = files[i];
                
                var folder = HttpContext.Current.Server.MapPath("~/Attachments/" + id + "/"+ Adddate + "/");
                if (!Directory.Exists(folder))
                {
                    //create folder
                    Directory.CreateDirectory(folder);
                    
                }
              
                string rootpath = "~/Attachments/" + id + "/" + Adddate+"/"+ file.FileName;
                Path[i] = rootpath.Substring(1);
                file.SaveAs(HttpContext.Current.Server.MapPath(rootpath));
            }
            attachments.FilePath = "/Attachments/" + id + "/" + Adddate + "/";
            attachmentcontroller = new AttachmentController();
            if (attachmentcontroller.creation(attachments))
            {
                return Path;
            }
            return null;
        }


        [HttpGet]
        public IEnumerable<post> posts(int id)
        {
            return _context.posts.Where(c => c.cityid == id).ToList();
        }

        // POST: api/Post
        public void Post([FromBody]string value)
        {
            
        }

        // PUT: api/Post/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Post/5
        public void Delete(int id)
        {
        }


        public async Task<IHttpActionResult> Addattachment(Attachments attachments)
        {
            PostController uploadfiles = new PostController();

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri("localhost:57955");

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Reply = await client.GetAsync("api/Employee/studentnmberexist/"+attachments.StudentID);
                if (Reply.IsSuccessStatusCode)
                {
                    if (uploadfiles.uploadfiles(attachments.ID) == null)
                        return BadRequest();
                    _context.attachment.Add(attachments);
                    _context.SaveChanges();
                    return Ok();
                }
                else
                    return NotFound();        
            }
        }
    }
}
