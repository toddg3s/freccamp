namespace freccamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Campers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Parentname = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        RiderLevel = c.Int(nullable: false),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Camps",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Advanced = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Camps");
            DropTable("dbo.Campers");
        }
    }
}
