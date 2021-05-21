using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers.Enum
{
    public class Religion
    {
        public enum religion
        {
           [Display(Name="مسلم")]
            muslim,

           [Display(Name = "مسيحي")]
           chirstian,

           [Display(Name = "اخري")]
           other
        }
    }
}