namespace UserManagement_EF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingProvinceTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Provinces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Addresses", "Province_Id", c => c.Int());
            CreateIndex("dbo.Addresses", "Province_Id");
            AddForeignKey("dbo.Addresses", "Province_Id", "dbo.Provinces", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Province_Id", "dbo.Provinces");
            DropIndex("dbo.Addresses", new[] { "Province_Id" });
            DropColumn("dbo.Addresses", "Province_Id");
            DropTable("dbo.Provinces");
        }
    }
}
