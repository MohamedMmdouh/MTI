using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class News
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "نوع الخبر")]
        public String category { get; set; }
        [Required]
        [Display(Name ="تفاصيل الخبر")]
        public String Details { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public DateTime Date { get; set; }
    }
}