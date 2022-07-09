namespace UserManagement_EF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialChanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street1 = c.String(),
                        City = c.Int(nullable: false),
                        Postal = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Qty = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                        ShippingAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.ShippingAddress_Id)
                .Index(t => t.ShippingAddress_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ShippingAddress_Id", "dbo.Addresses");
            DropIndex("dbo.Orders", new[] { "ShippingAddress_Id" });
            DropTable("dbo.Orders");
            DropTable("dbo.Addresses");
        }
    }
}
