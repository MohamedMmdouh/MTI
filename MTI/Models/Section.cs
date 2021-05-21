using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Section
    {
        public int ID { get; set; }

        [Display(Name ="الفرقه الدراسيه")]
        public String Level { get; set; }
    }
}