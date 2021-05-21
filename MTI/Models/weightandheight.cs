using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class weightandheight
    {
        public int ID { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public String section { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Display(Name = "الرقم العسكري")]
        public int StudentID { get; set; }
    }
}