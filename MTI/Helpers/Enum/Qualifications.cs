using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Helpers.Enum
{
    public class Qualifications
    {
       
            public enum qualification
            {
                [Display(Name = "ثانوية_عامة")]
                general,

                [Display(Name = "ثانوية_ازهرية")]
                Azhar
            }
        
    }
}

