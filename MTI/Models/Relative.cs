using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Relative
    {

        [Key,ForeignKey("Students")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "اسم الوالد")]
        public String fathername { get; set; }

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "التليفون")]
        public String fatherNum { get; set; }


        [Required]
        [Display(Name = "الوظيفة")]
        public String fatherJob { get; set; }

        [Required]
        [Display(Name = "المؤهل")]
        public String fatherqualification { get; set; }

        [Required]
        [Display(Name = "اسم الوالدة")]
        public String mothername {get; set;}

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "التليفون")]
        public String mothernum { get; set; }

        [Required]
        [Display(Name = "الوظيفة")]
        public String motherJob { get; set; }

        [Required]
        [Display(Name = "المؤهل")]
        public String motherqualification { get; set; }

        [Required]
        [Display(Name = "اسم ولي الامر")]
        public String Responsable { get; set; }

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "التليفون")]
        public String ResponsableNum { get; set; }

        [Required]
        [Display(Name = "عنوانه")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "المؤهل")]
        public String ResponsableJob { get; set; }


        [Required]
        [Display(Name ="اسم اقرب الاقارب")]
        public String Relativename { get; set; }

        [Required]
        [Display(Name = "عنوانه")]
        public String Relativeaddress { get; set; }

        [Required]
        [Display(Name = "درجة القرابة")]
        public String  Relationship{ get; set; }

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = " التليفون")]
        public String Relativenum { get; set; }

        [Required]
        [Display(Name = "الوظيفة ")]
        public String Job { get; set; }

        [Required]
        [Display(Name = "عنوان العمل")]
        public String JobAddress { get; set; }

        [Required]
        [Display(Name = "عدد الأخوة")]
        public int Numofbrothers { get; set; }

        [Required]
        [Display(Name = "ترتيبه في الاسرة")]
        public int NumAmongBrothers { get; set; }

        [Display(Name = "الدخل الشهري للاسرة")]
        public int TotalSalary { get; set; }

        public virtual Students Students { get; set; }
    }

}