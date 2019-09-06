namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Month", c => c.String());
            AddColumn("dbo.Customers", "Day", c => c.String());
            AddColumn("dbo.Customers", "Year", c => c.String());
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickupDay", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "MonthlyBalance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MonthlyBalance", c => c.Double(nullable: false));
            AlterColumn("dbo.Customers", "PickupDay", c => c.String());
            AlterColumn("dbo.Customers", "EndDate", c => c.String());
            AlterColumn("dbo.Customers", "StartDate", c => c.String());
            DropColumn("dbo.Customers", "Year");
            DropColumn("dbo.Customers", "Day");
            DropColumn("dbo.Customers", "Month");
        }
    }
}
