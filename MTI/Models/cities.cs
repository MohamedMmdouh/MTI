using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class cities
    {
        public int ID { get; set; }

        [Display(Name="المحافظة")]
        public  String name { get; set; }
    }
}