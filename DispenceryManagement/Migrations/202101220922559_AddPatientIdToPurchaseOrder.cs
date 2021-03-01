namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPatientIdToPurchaseOrder : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PurchaseCourses", name: "Patients_Id", newName: "PatientId");
            RenameIndex(table: "dbo.PurchaseCourses", name: "IX_Patients_Id", newName: "IX_PatientId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PurchaseCourses", name: "IX_PatientId", newName: "IX_Patients_Id");
            RenameColumn(table: "dbo.PurchaseCourses", name: "PatientId", newName: "Patients_Id");
        }
    }
}
