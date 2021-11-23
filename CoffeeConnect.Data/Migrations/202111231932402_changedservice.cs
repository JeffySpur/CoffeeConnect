namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedservice : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Coffee", "AmountInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coffee", "AmountInStock", c => c.Int(nullable: false));
        }
    }
}
