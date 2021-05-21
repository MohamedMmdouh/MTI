using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Situations
    {
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Required]
        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "نوع الموقف")]
        [DataType(DataType.Text)]
        public String SituationType { get; set; }

        [Required]
        [Display(Name = "التفاصيل")]
        [DataType(DataType.MultilineText)]
        public String Details { get; set; }

        [Required]
        [Display(Name = "الاجراءات")]
        [DataType(DataType.MultilineText)]
        public String procedure { get; set; }

        [Display(Name = "التاريخ ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? date { get; set; }
    }
}