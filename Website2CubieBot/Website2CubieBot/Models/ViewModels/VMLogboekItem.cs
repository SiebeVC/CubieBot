using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models.ViewModels
{
    [NotMapped]
    public class VMLogboekItem
    {
        public List<Persoon> Personen { get; set; }
        public LogboekItem LogboekItem { get; set; }

        public VMLogboekItem()
        {
            Personen = new List<Persoon>();
        }
    }
}