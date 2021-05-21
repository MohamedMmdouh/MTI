using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MTI.Models
{
    public class Message
    {
        public int ID { get; set; }

        [Required]
        public String From { get; set; }

        [Required]
        public String to { get; set; }

        [Required]
        public String MessageContent { get; set; }

        public DateTime Date { get; set; }
    }
}