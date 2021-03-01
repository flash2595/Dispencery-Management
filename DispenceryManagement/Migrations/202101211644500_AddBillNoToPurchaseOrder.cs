namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBillNoToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseCourses", "BillNo", c => c.String(nullable: false, maxLength: 11));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseCourses", "BillNo");
        }
    }
}
