namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ohLord : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "DayOfWeek", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "DayOfWeek", c => c.Int());
        }
    }
}
