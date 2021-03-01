namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddassignedRoleNametoPatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AssignedRoleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "AssignedRoleName");
        }
    }
}
