namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class heyheyItsAMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PickupDay", c => c.Int(nullable: false));
            AddColumn("dbo.Employees", "ConfirmPickup", c => c.Boolean(nullable: false));
            AddColumn("dbo.Employees", "Charges", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "Charges");
            DropColumn("dbo.Employees", "ConfirmPickup");
            DropColumn("dbo.Employees", "PickupDay");
        }
    }
}
