namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMedicinetypeandUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "MedicineType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MedicineType");
        }
    }
}
