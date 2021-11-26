namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migrationforpurchase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CoffeeId = c.Int(nullable: false),
                        LbsOfCoffee = c.Int(nullable: false),
                        DateofPurchase = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Coffee", t => t.CoffeeId, cascadeDelete: true)
                .ForeignKey("dbo.Customer", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.CoffeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchase", "CustomerId", "dbo.Customer");
            DropForeignKey("dbo.Purchase", "CoffeeId", "dbo.Coffee");
            DropIndex("dbo.Purchase", new[] { "CoffeeId" });
            DropIndex("dbo.Purchase", new[] { "CustomerId" });
            DropTable("dbo.Purchase");
        }
    }
}
