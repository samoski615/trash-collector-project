namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingPropertiesToUseGeocoding : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "StateAbbreviation", c => c.String());
            AddColumn("dbo.Addresses", "Country", c => c.String());
            DropColumn("dbo.Addresses", "State");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Addresses", "State", c => c.String());
            DropColumn("dbo.Addresses", "Country");
            DropColumn("dbo.Addresses", "StateAbbreviation");
        }
    }
}
