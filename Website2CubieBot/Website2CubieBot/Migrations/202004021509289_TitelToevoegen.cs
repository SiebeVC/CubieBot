namespace Website2CubieBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TitelToevoegen : DbMigration
    {
        public override void Up()
        {
            AddColumn("CubieBot.Taals", "Titel", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("CubieBot.Taals", "Titel");
        }
    }
}
