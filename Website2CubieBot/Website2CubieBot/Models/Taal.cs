using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models
{
    public class Taal
    {
        [Key()]
        public int Id { get; set; }

        public TaalKeuze Keuze { get; set; }
        public string Titel { get; set; }
        public string Inhoud { get; set; }
        public int Volgorde { get; set; }
        public string Locatie { get; set; }


        [NotMapped]
        public string[] ArrInhoud { get; set; }


    }
    public enum TaalKeuze
    {
        Nederlands,
        Frans,
        Engels
    }
}