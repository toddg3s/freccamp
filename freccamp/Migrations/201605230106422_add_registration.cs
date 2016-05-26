namespace freccamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_registration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Registrations",
                c => new
                    {
                        RegistrationId = c.Int(nullable: false, identity: true),
                        ContactName = c.String(),
                        ContactEmail = c.String(),
                        ContactPhone = c.String(),
                    })
                .PrimaryKey(t => t.RegistrationId);
            
            CreateTable(
                "dbo.CampRegistration",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        RegistrationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.RegistrationId })
                .ForeignKey("dbo.Camps", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.RegistrationId);
            
            CreateTable(
                "dbo.CamperRegistration",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RegistrationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.RegistrationId })
                .ForeignKey("dbo.Campers", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Registrations", t => t.RegistrationId, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.RegistrationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CamperRegistration", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.CamperRegistration", "Id", "dbo.Campers");
            DropForeignKey("dbo.CampRegistration", "RegistrationId", "dbo.Registrations");
            DropForeignKey("dbo.CampRegistration", "Id", "dbo.Camps");
            DropIndex("dbo.CamperRegistration", new[] { "RegistrationId" });
            DropIndex("dbo.CamperRegistration", new[] { "Id" });
            DropIndex("dbo.CampRegistration", new[] { "RegistrationId" });
            DropIndex("dbo.CampRegistration", new[] { "Id" });
            DropTable("dbo.CamperRegistration");
            DropTable("dbo.CampRegistration");
            DropTable("dbo.Registrations");
        }
    }
}
