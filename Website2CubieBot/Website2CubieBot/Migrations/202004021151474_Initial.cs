namespace Website2CubieBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CubieBot.Fouts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Melding = c.String(),
                        InnerMelding = c.String(),
                        Tijdstip = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CubieBot.Taals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Keuze = c.Int(nullable: false),
                        Inhoud = c.String(),
                        Volgorde = c.Int(nullable: false),
                        Locatie = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("CubieBot.Taals");
            DropTable("CubieBot.Fouts");
        }
    }
}
