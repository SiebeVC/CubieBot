using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website_Met_Auth.Models
{
    public class Deadline
    {
        [Key()]
        public int DeadlineId { get; set; }
        public string Wat { get; set; }
        public string Wanneer { get; set; }
    }
}