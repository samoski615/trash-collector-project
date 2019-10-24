namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test34 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        AddressId = c.Int(nullable: false, identity: true),
                        StreetAddress = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZipCode = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.AddressId);
            
            AddColumn("dbo.Customers", "AddressId", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "AddressId");
            AddForeignKey("dbo.Customers", "AddressId", "dbo.Addresses", "AddressId", cascadeDelete: true);
            DropColumn("dbo.Customers", "StreetAddress");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "ZipCode");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ZipCode", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "StreetAddress", c => c.String());
            DropForeignKey("dbo.Customers", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Customers", new[] { "AddressId" });
            DropColumn("dbo.Customers", "AddressId");
            DropTable("dbo.Addresses");
        }
    }
}
