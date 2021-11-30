namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firstnamelastname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Purchase", "FirstName", c => c.String());
            AddColumn("dbo.Purchase", "LastName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Purchase", "LastName");
            DropColumn("dbo.Purchase", "FirstName");
        }
    }
}
