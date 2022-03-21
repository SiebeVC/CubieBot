using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeerdereTalenCubieBotWebsite.Models
{
    public class LogboekElement
    {
        public string Naam { get; set; }
        public DateTime Wanneer { get; set; }
        public string Hoelang { get; set; }
        public string WatNed { get; set; }
        public string WatFra { get; set; }
        public string WatEng { get; set; }

        public LogboekElement(string naam, DateTime wanneer, string hoelang, string watNed, string watFra, string watEng)
        {
            Naam = naam;
            Wanneer = wanneer;
            Hoelang = hoelang;
            WatNed = watNed;
            WatFra = watFra;
            WatEng = watEng;
        }
    }
}