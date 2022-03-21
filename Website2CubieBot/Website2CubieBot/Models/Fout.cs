using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Website2CubieBot.Models
{
    public class Fout
    {
        [Key()]
        public int Id { get; set; }

        public string Melding { get; set; }
        public string InnerMelding { get; set; }

        public DateTime Tijdstip { get; set; }
    }
}