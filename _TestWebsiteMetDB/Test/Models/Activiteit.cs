using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using Test.Properties;
using System.Data;

namespace Test.Models
{
    public class Activiteit
    {
        protected DataRow datarow;



        public int Id { get; set; }
        public string  Naam { get; set; }
        public DateTime Datum { get; set; }
        public string  Wat { get; set; }
        public string Hoelang { get; set; }

        internal bool Load(DataRow data)
        {
            try
            {
                datarow = data;
                Id = data.Field<int>("LogboekId");
                Naam = data.Field<string>("Naam");
                Datum = data.Field<DateTime>("Datum");
                Wat = data.Field<string>("Wat");
                Hoelang = data.Field<string>("Hoelang");
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}