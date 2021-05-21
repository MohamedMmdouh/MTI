using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class AbsantDetails
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "الجهه")]
        public String Department { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name ="أسم الطالب")]
        public String Studname { get; set; }
    }
}