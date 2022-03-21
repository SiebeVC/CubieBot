using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OfficialWebsiteCubieBot.Models
{
    public class LogboekContext : DbContext
    {
        public LogboekContext() : base()
        {
            //Database.SetInitializer<LogboekContext>(new DropCreateDatabaseAlways<LogboekContext>());
        }
        public DbSet<Logboek> Logboeken { get; set; }
    }
}