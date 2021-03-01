namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ak_UpdateMedicineTypeInsert : DbMigration
    {
        public override void Up()
        {
            Sql("update MembershipTypes set MedicineType='Generic' where Id=1");
            Sql("update MembershipTypes set MedicineType='Non-Generic' where Id=2");
            Sql("Insert into MembershipTypes (Id,DiscountRate,MedicineType) values (3,5,'Common')");
        }
        
        public override void Down()
        {
        }
    }
}
