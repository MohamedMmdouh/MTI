using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class punishment
    {
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Required]
        [Display(Name ="الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "بند الاوامر")]
        [DataType(DataType.PhoneNumber)]
        public string order { get; set; }


        [Required]
        [Display(Name = "الآمر بالعقوبة")]
        [DataType(DataType.Text)]
        public String WhoApplyIt { get; set; }

        [Required]
        [Display(Name = "الجريمة")]
        [DataType(DataType.Text)]
        public string crime { get; set; }

        [Required]
        [Display(Name = "العقوبة")]
        [DataType(DataType.MultilineText)]
        public String punshiment { get; set; }

        [Required]
        [Display(Name = "الدرجات المفقوده ايذاء العقوبة")]
        [DataType(DataType.PhoneNumber)]
        public float MinusGrades { get; set; }

        [Display(Name = "القسم")]
        [DataType(DataType.Text)]
        public String level { get; set; }

        [Display(Name = "عزل")]
        [DataType(DataType.Text)]
        public Boolean remove { get; set; }

        [Display(Name = "انذار بالفصل")]
        [DataType(DataType.Text)]
        public Boolean alert { get; set; }


        [Display(Name = "موقف العقوبة")]
        [DataType(DataType.Text)]
        public Boolean Status { get; set; }

        [Display(Name = "تاريخ تسجيل العقوبة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? PunshimentDate { get; set; }

    }
}