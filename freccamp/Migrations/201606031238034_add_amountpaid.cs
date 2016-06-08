namespace freccamp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_amountpaid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registrations", "AmountPaid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Registrations", "AmountPaid");
        }
    }
}
