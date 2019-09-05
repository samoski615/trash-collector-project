namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StartDate", c => c.String());
            AddColumn("dbo.Customers", "EndDate", c => c.String());
            AddColumn("dbo.Customers", "PickupDay", c => c.String());
            DropColumn("dbo.Customers", "DayOfTheWeek");
            DropColumn("dbo.Customers", "DayOfTheMonth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "DayOfTheMonth", c => c.String());
            AddColumn("dbo.Customers", "DayOfTheWeek", c => c.String());
            DropColumn("dbo.Customers", "PickupDay");
            DropColumn("dbo.Customers", "EndDate");
            DropColumn("dbo.Customers", "StartDate");
        }
    }
}
