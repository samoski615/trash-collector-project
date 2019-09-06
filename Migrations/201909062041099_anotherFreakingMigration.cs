namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class anotherFreakingMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ExtraDate", c => c.String());
            AlterColumn("dbo.Customers", "StartDate", c => c.String());
            AlterColumn("dbo.Customers", "EndDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "EndDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "StartDate", c => c.DateTime());
            DropColumn("dbo.Customers", "ExtraDate");
        }
    }
}
