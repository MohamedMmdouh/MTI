using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Reward
    {
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        public Students students { get; set; }

        [Required]
        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "موقع المكافأة")]
        [DataType(DataType.Text)]
        public String WhoApplyIt { get; set; }

        [Required]
        [Display(Name = "سبب المكافأة")]
        [DataType(DataType.MultilineText)]
        public string Reward_reason { get; set; }

        [Required]
        [Display(Name = "المكافأة")]
        [DataType(DataType.MultilineText)]
        public String reward { get; set; }

        [Required]
        [Display(Name = "الدرجات ")]
        [DataType(DataType.PhoneNumber)]
        public float plusGrades { get; set; }

        [Display(Name = "تاريخ تسجيل المكافأة")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime? RewardDate { get; set; }

    }
}