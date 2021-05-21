using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class post
    {
        public int ID { get; set; }

        [Display(Name="مركز")]
        public string Name { get; set; }

        [ForeignKey("cityid")]
        public cities Cities { get; set; }

        [Display(Name = "المدينه")]
        public int cityid { get; set; }

    }
}