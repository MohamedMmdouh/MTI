using MTI.Helpers;
using MTI.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Students
    {
        [Key]
        public int ID { get; set; }

        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "لا يمكن ان يكون الرقم اقل من 0")]
        [Required(ErrorMessage = "يجب ادخال رقم الطالب ")]
        [Range(10000, 99999, ErrorMessage = "يتكون الرقم من 5 خانات")]
        [Display(Name = "الرقم العسكري")]
        public int StudentNumber { get; set; }

        [Display(Name = "الدفعه")]
        public Batch batch { get; set; }

        [Required]
        [Display(Name = "الدفعه")]
        public int batchid { get; set; }

        [Required]
        [Display(Name = "تاريخ الالتحاق")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd } ", ApplyFormatInEditMode = true)]
        public DateTime? getindate { get; set; }

        [Display(Name = "تاريخ الانضمام للمعهد")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public DateTime? joindate { get; set; }
       
        [Display(Name = "تاريخ التخرج ")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        public DateTime? graduatedate { get; set; }

        [Display(Name="المؤهل الدراسي")]
        public String Qualification { get; set; }

        [Required]
        [Display(Name = "رتبه")]
        public String grade { get; set; }

        [Required(ErrorMessage = "اسم الطالب مطلوب")]
        [Display(Name = "الإسم")]
        public String Name { get; set; }

        [Display(Name = "القسم")]
        public Section Section { get; set; }

        [Required]
        [Display(Name = "القسم")]
        public int SectionID { get; set; }

        [Required(ErrorMessage = " التخصص الرئيسي مطلوب")]
        [Display(Name = "التخصص الرئيسي")]
        public string main_specialization { get; set; }


        [Display(Name = "التخصص الدقيق")]
        public specialization specialization { get; set; }

        [Display(Name = "التخصص الدقيق")]
        public int SpecializationID { get; set; }

        [Required(ErrorMessage = "تحديد السلاح مطلوب")]
        [Display(Name = "السلاح")]
        public String armyspecialization { get; set; }


        [Required(ErrorMessage = "ادخل ديانه الطالب")]
        [Display(Name = "الديانة")]
        public String Religion { get; set; }

        [Required(ErrorMessage = "ادخل جنسية الطالب")]
        [Display(Name = "الجنسية")]
        public String Nationality { get; set; }

        [MaxLength(14, ErrorMessage = "الرقم القومي يجب ألا يزيد عن 14 رقم")]
        [MinLength(14, ErrorMessage = "الرقم القومي يجب ألا يقل عن 14 رقم")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "لا يمكن ان يكون الرقم اقل من 0")]
        [Required(ErrorMessage = "الرقم القومي مطلوب")]
        [Display(Name = "الرقم القومي")]
        [DataType(DataType.PhoneNumber)]
        public String SSN { get; set; }

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "التليفون")]
        [DataType(DataType.PhoneNumber)]
        public String Mobile { get; set; }

        [MaxLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يزيد عن 11 رقم")]
        [MinLength(11, ErrorMessage = "رقم الهاتف  يجب ألا يقل عن 11 رقم")]
        [Required(ErrorMessage = "رقم التليفون مطلوب")]
        [Display(Name = "التليفون")]
        [DataType(DataType.PhoneNumber)]
        public String secondNum { get; set; }

        [Required(ErrorMessage = "فصيلة الدم مطلوبة")]
        [Display(Name = "فصيله الدم")]
        public String Blood_Type { get; set; }

        [Display(Name = "تاريخ الميلاد")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd} ", ApplyFormatInEditMode = true)]
        [Min16Years]
        public DateTime ? BirthDate { get; set; }

        [Required]
        [Display(Name ="محل الميلاد")]
        public String PlaceofBirth { get; set; }

        [Required]
        [Display(Name = "المحافظة")]
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

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [Required]
        [Display(Name = "فصيله")]
        public string Fasila { get; set; }

        [Required]
        [Display(Name = "سريه")]
        public string saria { get; set; }

        [Required]
        [Display(Name = "كتيبه")]
        public string Katiba { get; set; }

        [Display(Name = "جماعة")]
        public string group{ get; set; }

        [Display(Name = "عنوان الفيس بوك")]
        public String Fburl { get; set; }

        [Display(Name="السلوك")]
        public float behaviour { get; set; }

        public virtual bodydetails Bodydetails { get; set; }

        public virtual Relative relative { get; set; }

        public virtual Qualifications qualifications { get; set; }

        public ICollection<Shooting> shootings { get; set; }

        public ICollection<Reward> Rewards { get; set; }
        public ICollection<Attendance>attendances { get; set; }
        public ICollection<punishment> punishments { get; set; }
        public ICollection<Situations> situations { get; set; }
        public ICollection<Batch> batches { get; set; }

        public bool IsVIsible { get; set; }
        public Students()
        {
            Rewards = new Collection<Reward>();
            punishments = new Collection<punishment>();
            shootings = new Collection<Shooting>();
            batches = new Collection<Batch>();
            attendances = new Collection<Attendance>();
        }

     
    }
}//DESKTOP-HB2PMFE\SQLEXPRESS
 //Admin
 //username:admin pass:User-2018 moodle
 //moodleuser@localhost
 //User-mti-2018  mti97
 //Asp/123_FCIH>MTi