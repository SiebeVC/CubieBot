using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;


namespace Website_Met_Auth.Models
{
    public class LogboekElement
    {
        [Key()]
        public int ElementId { get; set; }
        public string Naam { get; set; }
        public string Wanneer { get; set; }
        public string Hoelang { get; set; }
        public string WatNed { get; set; }
        public string WatFra { get; set; }
        public string WatEng { get; set; }
    }
}