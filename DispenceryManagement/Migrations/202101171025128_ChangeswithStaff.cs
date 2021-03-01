namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeswithStaff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AssignedStaffRoles_Id", c => c.Int());
            CreateIndex("dbo.Patients", "AssignedStaffRoles_Id");
            AddForeignKey("dbo.Patients", "AssignedStaffRoles_Id", "dbo.RoleAssignments", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AssignedStaffRoles_Id", "dbo.RoleAssignments");
            DropIndex("dbo.Patients", new[] { "AssignedStaffRoles_Id" });
            DropColumn("dbo.Patients", "AssignedStaffRoles_Id");
        }
    }
}
