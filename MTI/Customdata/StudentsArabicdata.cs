using MTI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Customdata
{
    public class StudentsArabicdata
    {
        public string ID { get; set; }

      
        [Display(Name = "الرقم العسكري")]
        public string StudentNumber { get; set; }


        [Display(Name = "الدفعه")]
        public string batchNo { get; set; }

        [Display(Name = "رتبه")]
        public string grade { get; set; }


        [Display(Name = "تاريخ الالتحاق")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd } ", ApplyFormatInEditMode = true)]
        public string getindate { get; set; }

        [Display(Name = "تاريخ الانضمام للمعهد")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public string Joindate { get; set; }

        [Display(Name = "تاريخ التخرج ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public string graduatedate { get; set; }

        [Display(Name = "المؤهل الدراسي")]
        public String Qualification { get; set; }

        [Display(Name = "تخصص المؤهل")]
        public String Qualificationspecialize { get; set; }

        [Display(Name = "شعبه")]
        public String Qualificationdepart { get; set; }


        [Display(Name = "تاريخ الحصول عليه ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public string qualificationgetdate { get; set; }


        [Display(Name = "مجموع الطالب")]
        public string GPA { get; set; }

        [Required(ErrorMessage = "اسم الطالب مطلوب")]
        [Display(Name = "الإسم")]
        public String Name { get; set; }


        [Required]
        [Display(Name = "القسم")]
        public string Level { get; set; }

        [Required]
        [Display(Name = "التخصص الرئيسي")]
        public string generalspecialize { get; set; }

        [Required]
        [Display(Name = "التخصص الدقيق")]
        public string Specialization { get; set; }

        [Display(Name = "الديانة")]
        public String Religion { get; set; }

        [Display(Name = "الجنسية")]
        public String Nationality { get; set; }

        [Display(Name = "الوزن")]
        public String Weight { get; set; }

        [Display(Name = "الطول")]
        public String height { get; set; }

        [Display(Name = "التناسق")]
        public String bodysymetry { get; set; }

        [Display(Name = "الرقم القومي")]
        public String SSN { get; set; }

     
        [Display(Name = "التليفون")]
        public String Mobile { get; set; }

    
        [Display(Name = "التليفون")]
        public String secondNum { get; set; }

        [Display(Name = "السلاح")]
        public String wepon { get; set; }

        [Required(ErrorMessage = "فصيلة الدم مطلوبة")]
        [Display(Name = "فصيله الدم")]
        public String Blood_Type { get; set; }


        [Display(Name = "تاريخ الميلاد")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public string BirthDate { get; set; }

        [Required]
        [Display(Name = "محل الميلاد")]
        public String PlaceofBirth { get; set; }

        [Required]
        [Display(Name = " المحافظة")]
        public String cityofbirth { get; set; }

        [Required(ErrorMessage = "عنوان الطالب مطلوب")]
        [Display(Name = "العنوان")]
        public String Address { get; set; }

        [Required]
        [Display(Name = "المحافظة")]
        public String City { get; set; }

        [Required]
        [Display(Name = "المركز/القسم")]
        public String Post { get; set; }

        [Display(Name = "البريد الالكتروني")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public String Email { get; set; }

        [Display(Name = "صوره الطالب")]
        public String Image { get; set; }

        [Display(Name = "جماعة")]
        public string gama3a { get; set; }

        [Required]
        [Display(Name = "فصيله")]
        public string Fasila { get; set; }

        [Required]
        [Display(Name = "سريه")]
        public string saria { get; set; }

        [Display(Name = "كتيبه")]
        public string Katiba { get; set; }

        [Display(Name = "عنوان الفيس بوك")]
        public String Fburl { get; set; }

        [Display(Name = "السلوك")]
        public string behaviour { get; set; }


        [Display(Name = "اسم الوالد")]
        public String fathername { get; set; }

        [Display(Name = "التليفون")]
        public String fatherNum { get; set; }

        [Display(Name = "الوظيفة")]
        public String fatherjob { get; set; }

        [Display(Name = "المؤهل")]
        public String fatherqualifcation { get; set; }

        [Display(Name = "اسم الوالدة")]
        public String mothername { get; set; }

        [Display(Name = "التليفون")]
        public String motherNum { get; set; }

        [Display(Name = "الوظيفة")]
        public String motherjob { get; set; }

        [Display(Name = "المؤهل")]
        public String motherqualifcation { get; set; }

        [Display(Name = "اسم ولي الامر")]
        public String responsiblename { get; set; }

        [Display(Name = "التليفون")]
        public String responsibleNum { get; set; }

        [Display(Name = "وظيفته")]
        public String responsiblejob { get; set; }

        [Display(Name = "عنوان")]
        public String responsibleaddress { get; set; }

        [Display(Name = " اقرب الاقارب")]
        public String Relativename { get; set; }
        
        [Display(Name = "عنوان")]
        public String Relativeadress { get; set; }

        [Display(Name = "درجة القرابه")]
        public String Relationship { get; set; }

        [Display(Name = "رقم التليفون")]
        public String RelativeNum { get; set; }

        [Display(Name = "وظيفته")]
        public String Job { get; set; }

        [Display(Name = "عنوان العمل")]
        public String Jobaddress { get; set; }

        [Display(Name = "عدد الأخوة")]
        public string Numofbrothers { get; set; }

        [Display(Name = "ترتيبه في الاسرة")]
        public string NumAmongBrothers { get; set; }


        [Display(Name = "الدخل الشهري الاسرة")]
        public string totalsalary { get; set; }

        public ICollection<Shooting> shootings { get; set; }

        public ICollection<Reward> Rewards { get; set; }
        public ICollection<punishment> punishments { get; set; }
        public ICollection<Situations> situations { get; set; }
        public ICollection<Attendance> attendances { get; set; }

        public bool IsVIsible { get; set; }
        public StudentsArabicdata()
        {
            Rewards = new Collection<Reward>();
            punishments = new Collection<punishment>();
            shootings = new Collection<Shooting>();
            attendances = new Collection<Attendance>();
        }

    }
}