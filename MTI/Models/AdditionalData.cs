using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class AdditionalData
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        [Display(Name = "تفاصيل")]
        public string  Details { get; set; }

        [Display(Name = "الملحق")]
        public String Image { get; set; }

        [NotMapped] 
        public HttpPostedFileBase ImageFile { get; set; }
    }
}