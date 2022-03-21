namespace Website2CubieBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "CubieBot.LogboekItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Inhoud = c.String(),
                        Datum = c.DateTime(nullable: false),
                        Persoon_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CubieBot.Persoons", t => t.Persoon_Id)
                .Index(t => t.Persoon_Id);
            
            CreateTable(
                "CubieBot.Persoons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Voornaam = c.String(),
                        Achternaam = c.String(),
                        Email = c.String(),
                        GeboorteDatum = c.DateTime(nullable: false),
                        Gemeente = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "CubieBot.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "CubieBot.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("CubieBot.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("CubieBot.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "CubieBot.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "CubieBot.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("CubieBot.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "CubieBot.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("CubieBot.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("CubieBot.AspNetUserRoles", "UserId", "CubieBot.AspNetUsers");
            DropForeignKey("CubieBot.AspNetUserLogins", "UserId", "CubieBot.AspNetUsers");
            DropForeignKey("CubieBot.AspNetUserClaims", "UserId", "CubieBot.AspNetUsers");
            DropForeignKey("CubieBot.AspNetUserRoles", "RoleId", "CubieBot.AspNetRoles");
            DropForeignKey("CubieBot.LogboekItems", "Persoon_Id", "CubieBot.Persoons");
            DropIndex("CubieBot.AspNetUserLogins", new[] { "UserId" });
            DropIndex("CubieBot.AspNetUserClaims", new[] { "UserId" });
            DropIndex("CubieBot.AspNetUsers", "UserNameIndex");
            DropIndex("CubieBot.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("CubieBot.AspNetUserRoles", new[] { "UserId" });
            DropIndex("CubieBot.AspNetRoles", "RoleNameIndex");
            DropIndex("CubieBot.LogboekItems", new[] { "Persoon_Id" });
            DropTable("CubieBot.AspNetUserLogins");
            DropTable("CubieBot.AspNetUserClaims");
            DropTable("CubieBot.AspNetUsers");
            DropTable("CubieBot.AspNetUserRoles");
            DropTable("CubieBot.AspNetRoles");
            DropTable("CubieBot.Persoons");
            DropTable("CubieBot.LogboekItems");
        }
    }
}
