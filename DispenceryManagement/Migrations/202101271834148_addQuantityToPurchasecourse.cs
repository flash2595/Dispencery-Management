namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addQuantityToPurchasecourse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseCourses", "DispenceryItemQuantityPurchase", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseCourses", "DispenceryItemQuantityPurchase");
        }
    }
}
