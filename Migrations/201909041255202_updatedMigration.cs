namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MonthlyBalance", c => c.Double(nullable: false));
            AddColumn("dbo.Customers", "DayOfTheMonth", c => c.String());
            DropColumn("dbo.Customers", "Balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Balance", c => c.Double(nullable: false));
            DropColumn("dbo.Customers", "DayOfTheMonth");
            DropColumn("dbo.Customers", "MonthlyBalance");
        }
    }
}
