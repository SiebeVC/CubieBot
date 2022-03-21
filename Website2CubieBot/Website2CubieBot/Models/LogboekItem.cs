using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models
{
    public class LogboekItem
    {
        [Key()]
        public int Id { get; set; }

        public string Titel { get; set; }
        public string  Inhoud { get; set; }
        public DateTime Datum { get; set; }

        //Persoon wie het gedaan heeft
        public virtual Persoon Persoon { get; set; }
    }
}