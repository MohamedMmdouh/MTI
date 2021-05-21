using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers
{
    public class punshimentcastmodel
    {
        public int ID { get; set; }

        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Display(Name = "الآمر بالعقوبة")]
        [DataType(DataType.Text)]
        public String WhoApplyIt { get; set; }

        [Display(Name = "الجريمة")]
        [DataType(DataType.Text)]
        public string crime { get; set; }

        [Display(Name = "العقوبة")]
        [DataType(DataType.MultilineText)]
        public String punshiment { get; set; }

        [Display(Name = "الدرجات المفقوده ايذاء العقوبة")]
        [DataType(DataType.PhoneNumber)]
        public float MinusGrades { get; set; }

        [Display(Name = "تاريخ تسجيل العقوبة")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? PunshimentDate { get; set; }

        [Display(Name = "القسم")]
        [DataType(DataType.Text)]
        public String level { get; set; }

        public bool status { get; set; }

        public Boolean isvisible { get; set; } //access hidden fields from student
    }
}