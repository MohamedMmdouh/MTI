using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Shooting
    {
        public int ID { get; set; }
        [Required]
        [Display(Name ="أسم التمرين")]
        public String Trainingname { get; set; }

        [Required]
        [Display(Name ="عدد الطلقات")]
        [RegularExpression("([1-9][0-9]*)",ErrorMessage ="لا يمكن ان يكون الرقم اقل من 0")]
        public int numofbullet { get; set; }

        [Required]
        [Display(Name ="نوع السلاح")]
        public string weaponname { get; set; }

        [Required]
        [Display(Name = "أصابة")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "لا يمكن ان يكون الرقم اقل من 0")]
        public int numofsuccessshots { get; set; }

        [Required]
        [Display(Name ="التقدير")]
        public String Grade { get; set; }

        [Display(Name ="أخطاء الرامي")]
        public String ShootigErrors { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name ="تاريخ الرماية")]
        public DateTime Dateofshoot { get; set; }

        [Display(Name = "القسم")]
        public String level { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Display(Name = "الرقم العسكري")]
        public int StudentID { get; set; }
    }
}