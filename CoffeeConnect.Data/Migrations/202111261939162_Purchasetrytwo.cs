namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Purchasetrytwo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase", "OwnerId");
        }
    }
}
