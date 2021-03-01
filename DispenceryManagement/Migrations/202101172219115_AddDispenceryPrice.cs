namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDispenceryPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispenceryItems", "DispenceryItemPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispenceryItems", "DispenceryItemPrice");
        }
    }
}
