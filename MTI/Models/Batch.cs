using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Batch
    {
        public int ID { get; set; }

        [Display(Name="الدفعه")]
        public int batchNo { get; set; }
    }
}