using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models.ViewModels
{
    public class VMPersoon
    {
        public Persoon Persoon { get; set; }

        public List<LogboekItem> Logboek { get; set; }

        public VMPersoon(Persoon pers)
        {
            Persoon = pers;  
        }
        public VMPersoon()
        {

        }
    }
}