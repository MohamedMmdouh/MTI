using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class daily_attendance
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name ="قوة المعهد")]
        public int Total { get; set; }

        [Required]
        [RegularExpression("^[0-9]+$")]
        [Display(Name ="موجود")]
        [DataType(DataType.PhoneNumber)]
        public int AttendeesNum { get; set; }

        [Required]
        [Display(Name = "خارج")]
        [RegularExpression("^[0-9]+$")]
        [DataType(DataType.PhoneNumber)]
        public int AbsentNum { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "تاريخ تسجيل الحضور اليومي")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }

        public List<string> details { get; set; }

        [Display(Name = "تفاصيل الخوارج")]
        public List<AbsantDetails> AbsantDetails { get; set; }

        public daily_attendance()
        {
            this.AbsantDetails = new List<AbsantDetails>();
        }
    }
}