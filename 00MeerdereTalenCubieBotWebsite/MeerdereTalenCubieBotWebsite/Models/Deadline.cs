using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeerdereTalenCubieBotWebsite.Models
{
    public class Deadline
    {
        public string Wat { get; set; }
        public string Wanneer { get; set; }
        public string WatNed { get; set; }
        public string WatFra { get; set; }
        public string WatEng { get; set; }
        public string Link { get; set; }


        public Deadline(string wanneer, string watNed, string watEng, string watFra, string link = "")
        {
            Wanneer = wanneer;
            WatNed = watNed;
            WatFra = watFra;
            WatEng = watEng;
            if (link == "")
                Link = link;
            else
                Link = "../Content/Bestanden/" + link;
        }
    }
}