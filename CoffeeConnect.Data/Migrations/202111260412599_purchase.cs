namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class purchase : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Purchase", "DateofPurchase", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Purchase", "DateofPurchase", c => c.DateTime(nullable: false));
        }
    }
}
