using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class UserRoles
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name ="User Role")]
        public String RolesType { get; set; }
    }
}