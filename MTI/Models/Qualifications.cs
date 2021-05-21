using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Qualifications
    {
        [Key, ForeignKey("Students")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "المؤهل الدراسي")]
        public String Qualification { get; set; }

        [Required]
        [Display(Name = "تخصص المؤهل")]
        public String qualispecialize { get; set; }

        [Required]
        [Display(Name = "شعبه")]
        public String qualidepart { get; set; }

        [Required]
        [Display(Name = "تاريخ الحصول عليه")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public DateTime? qualigetdate { get; set; }

        [Required]
        [Display(Name = "المجموع")]
        public float gpa { get; set; }
        

        public virtual Students Students { get; set; }


    }
}