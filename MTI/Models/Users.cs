using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Users
    {
        [Required]
        public int ID { get; set; }

        [Required(ErrorMessage="Please enter Username"), MaxLength(30)]
        [DataType(DataType.Text)]
        [Display(Name = "اسم المستخدم")]
        public String Username { get; set; }

        [Required(ErrorMessage = "Please enter Password"), MaxLength(30)]
        [DataType(DataType.Password)]
        [Display(Name = "كلمه المرور")]
        public String Password  { get; set; }


        public UserRoles userRoles { get; set; }

        public int UserRoleID { get; set; }
    }
}