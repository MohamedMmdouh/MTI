using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers
{
    public class Shootingcastmodel
    {
        public int ID { get; set; }

        [Display(Name = "أسم التمرين")]
        public String Trainingname { get; set; }

        [Display(Name = "عدد الطلقات")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "لا يمكن ان يكون الرقم اقل من 0")]
        public int numofbullet { get; set; }

        [Display(Name = "نوع السلاح")]
        public string weaponname { get; set; }

        [Display(Name = "أصابة")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "لا يمكن ان يكون الرقم اقل من 0")]
        public int numofsuccessshots { get; set; }

        [Display(Name = "التقدير")]
        public String Grade { get; set; }

        [Display(Name = "أخطاء الرامي")]
        public String ShootigErrors { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Display(Name = "تاريخ الرماية")]
        public DateTime Dateofshoot { get; set; }

        [Display(Name = "القسم")]
        public String level { get; set; }

        [Display(Name = "الرقم العسكري")]
        public int StudentID { get; set; }

        public Boolean isvisible { get; set; }
    }
}