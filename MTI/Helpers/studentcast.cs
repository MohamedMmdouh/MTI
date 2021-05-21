using MTI.Migrations;
using MTI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Relative = MTI.Models.Relative;

namespace MTI.Helpers
{
    public class studentcast 
    {
        public int ID { get; set; }

        public int StudentNumber { get; set; }

        public Batch batch { get; set; }

        public int batchid { get; set; }


        public DateTime? getindate { get; set; }

        public DateTime? expectedgraduateddate { get; set; }

        public DateTime? graduatedate { get; set; }

        public String Qualification { get; set; }

        public int GPA { get; set; }


        public String Name { get; set; }
        public Section Section { get; set; }


        public int SectionID { get; set; }

        public specialization specialization { get; set; }

        public int SpecializationID { get; set; }

        public String Religion { get; set; }


        public String Nationality { get; set; }


        public String SSN { get; set; }

        public String Mobile { get; set; }

        public String secondNum { get; set; }

        public String Blood_Type { get; set; }


        public DateTime? BirthDate { get; set; }

    
        public String PlaceofBirth { get; set; }

        public String Address { get; set; }
        public String City { get; set; }

       
        public String Post { get; set; }

        public String Email { get; set; }

        public String Image { get; set; }

       [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

       
        public string Fasila { get; set; }

      
        public string saria { get; set; }

      
        public string Katiba { get; set; }

        public String Fburl { get; set; }

        public int behaviour { get; set; }


        public String Relativename { get; set; }

        public String Relationship { get; set; }
        public String RelativeNum { get; set; }

        public String Job { get; set; }

        public String Status { get; set; }

        public int Numofbrothers { get; set; }

        public int NumAmongBrothers { get; set; }

        public ICollection<Batch> batches { get; set; }

        public bool IsVIsible { get; set; }
        public studentcast()
        {
            batches = new Collection<Batch>();
        }

    }
}