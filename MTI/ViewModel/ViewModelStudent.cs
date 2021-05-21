using MTI.Helpers;
using MTI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MTI.ViewModel
{
    public class ViewModelStudent
    {

        public IEnumerable<Section> sections { get; set; }
        public IEnumerable<specialization> specialization { get; set; }
        public IEnumerable<Batch> batches { get; set; }
        public List<String> BloodType { get; set; }
        public studentcast students { get; set; }
        public String Title
        {
            get
            {
                if (students == null)
                    return "تسجيل";

                return "تعديل";
            }
        }
        public String value
        {
            get
            {
                if (students == null)
                    return "Enabled";

                return "disabled";
            }
        }
    }
}

