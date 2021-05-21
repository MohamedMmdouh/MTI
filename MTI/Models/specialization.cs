using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class specialization
    {
        public int ID { get; set; }
        
        [Display(Name ="تخصص")]
        public String specialty { get; set; }
    }
}