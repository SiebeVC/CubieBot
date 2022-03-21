using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OfficialWebsiteCubieBot.Models
{
    [Table("Logboek")]
    public class Logboek
    {
        [Key()]
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? Wanneer { get; set; }
        public string Hoelang { get; set; }
        public string Persoon { get; set; }


        public static Logboek BereidLogboekVoor()
        {
            Logboek logboek = new Logboek()
            {
                Wanneer = DateTime.Now
            };
            return logboek;
        }
    }
}