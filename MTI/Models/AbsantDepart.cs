using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class AbsantDepart
    {
        [Display(Name="تحت الملاحظة")]
        public int Underobservation { get; set; }

        [Display(Name = "مست خارجي")]
        public int outingmst { get; set; }

        [Display(Name = "أجازة بتصريح")]
        public int permititedleave { get; set; }

        [Display(Name = "أجازة مرضية")]
        public int Sickleave { get; set; }

        [Display(Name = "سجن")]
        public int prison { get; set; }


        [Display(Name = "مكتب")]
        public int office { get; set; }


        [Display(Name = "مأمورية")]
        public int Mission { get; set; }


        [Display(Name = "أختبارات")]
        public int Tests { get; set; }


        [Display(Name = "تدريب خارجي")]
        public int  outtrainning { get; set; }


        [Display(Name = "زيارة")]
        public int visit { get; set; }


        [Display(Name = "أتيام")]
        public int Atiam { get; set; }


        [Display(Name = "نوبتجي")]
        public int nabtchy { get; set; }


        [Display(Name = "خدمة")]
        public int services { get; set; }


        [Display(Name = "عيادة")]
        public int clinic { get; set; }
    }

}