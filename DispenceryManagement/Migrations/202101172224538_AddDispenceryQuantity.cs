namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDispenceryQuantity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispenceryItems", "DispenceryItemQuantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispenceryItems", "DispenceryItemQuantity");
        }
    }
}
