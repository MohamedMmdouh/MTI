using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Attendance
    {
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Required]
        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }


        [Display(Name = "تاريخ")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? Date { get; set; }

        [Display(Name = "عيادة")]//صباحية/ طارئة
        public String Clinic_type { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "من")]//تحت الملاحظة
        public DateTime? underObservation_from { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "إلي")]//تحت الملاحظة
        public DateTime? underObservation_to { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "من")]//خارجي مستشفي
        public DateTime? hosptital_from { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "إلي")]//خارجي مستشفي
        public DateTime? hosptital_to { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "من")]//تغيب 
        public DateTime? Absant_from { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "إلي")]//تغيب 
        public DateTime? Absant_to{ get; set; }

        [Display(Name = "تغيب محاضرة")] 
        public Boolean lec_absant { get; set; }

        [Display(Name = "راحة / معافاة")] 
        public Boolean  recovery{ get; set; }

        [Display(Name = "تفاصيل")]
        public String Details { get; set; }

        [Required]
        [Display(Name = "اجمالي الدرجة")]
        public String Totalminusgrade { get; set; }

    }

}