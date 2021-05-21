using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers
{
    public class Relativecastmodel
    {
        public int ID { get; set; }

        [Display(Name="الرقم العسكري")]
        public int StudentNumber { get; set; }

        [Display(Name = "الاسم")]
        public String StudentNAme { get; set; }

        [Display(Name = "اسم اقرب الاقارب")]
        public String Relativename { get; set; }

        [Display(Name = "رقم الوالد")]
        public String FatherNum { get; set; }

        [Display(Name = "صفته")]
        public String Relationship { get; set; }

        [Display(Name = "رقم التليفون")]
        public String RelativeNum { get; set; }

        [Display(Name = "وظيفة الوالد")]
        public String Job { get; set; }

        [Display(Name = "وظيفة اقرب الاقارب")]
        public String Status { get; set; }

        [Display(Name = "عدد الأخوة")]
        public int Numofbrothers { get; set; }

        [Display(Name = "ترتيبه في الاسرة")]
        public int NumAmongBrothers { get; set; }
        public bool isvisible { get; set; }
    }
}