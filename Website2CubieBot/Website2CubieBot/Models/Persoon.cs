using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models
{
    //Deze klas dient voor het aanduiden, van personen in het logboek
    public class Persoon
    {
        [Key()]
        public int Id { get; set; }

        public string Voornaam { get; set; }
        public string Achternaam { get; set; }
        public string Email { get; set; }
        public DateTime GeboorteDatum { get; set; }
        public string Gemeente { get; set; }


        public virtual List<LogboekItem> LogboekItems { get; set; }
    }
}