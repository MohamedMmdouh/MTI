using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Attachments
    {
        public int ID { get; set; }

        [ForeignKey("StudentID")]
        [Display(Name = "الرقم العسكري")]
        public Students students { get; set; }

        [Required]
        [Display(Name = "الرقم العسكري")]
        [DataType(DataType.PhoneNumber)]
        public int StudentID { get; set; }

        [Required]
        [Display(Name = "نوع الملحق ")]
        public String Attachmenttype { get; set; }

        [Required]
        [Display(Name = "الجهة المانحة")]
        public String Organization { get; set; }
        [Display(Name = "الملفات")]
        public String FilePath { get; set; }
    }
}