using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers
{
    public class rewardcastmodel
    {
        public int ID { get; set; }

        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Display(Name = "موقع المكافأة")]
        [DataType(DataType.Text)]
        public String WhoApplyIt { get; set; }

        [Display(Name = "سبب المكافأة")]
        [DataType(DataType.Text)]
        public string Reward_reason { get; set; }

        [Display(Name = "المكافأة")]
        [DataType(DataType.MultilineText)]
        public String reward { get; set; }

        [Display(Name = "الدرجات ")]
        [DataType(DataType.PhoneNumber)]
        public float plusGrades { get; set; }

        [Display(Name = "تاريخ تسجيل المكافأة")]

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? RewardDate { get; set; }

        public Boolean isvisible { get; set; } //access hidden fields from student


    }
}