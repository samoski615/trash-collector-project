namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migration1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PickupDay", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PickupDay", c => c.Int(nullable: false));
        }
    }
}
