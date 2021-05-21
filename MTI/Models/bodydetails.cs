using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class bodydetails
    {
        [Key, ForeignKey("Students")]
        public int ID { get; set; }

        [Display(Name = "الوزن")]
        public float weight { get; set; }

        [Display(Name = "الطول")]
        public float height { get; set; }

        [Display(Name = "التناسق")]
        public float bodysymmetry { get; set; }

        public virtual Students Students { get; set; }

    }
}