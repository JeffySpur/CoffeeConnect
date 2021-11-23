namespace CoffeeConnect.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedabunchofstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coffee", "CoffeeDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coffee", "CoffeeDescription");
        }
    }
}
