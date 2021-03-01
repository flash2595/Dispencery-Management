namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolestoUser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoleAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberName = c.String(),
                        RoleId = c.Byte(nullable: false),
                        RoleName = c.String(),
                        AddedDateTime = c.DateTime(nullable: false),
                        StaffRoles_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StaffRoles", t => t.StaffRoles_Id)
                .Index(t => t.StaffRoles_Id);
            
            CreateTable(
                "dbo.StaffRoles",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoleAssignments", "StaffRoles_Id", "dbo.StaffRoles");
            DropIndex("dbo.RoleAssignments", new[] { "StaffRoles_Id" });
            DropTable("dbo.StaffRoles");
            DropTable("dbo.RoleAssignments");
        }
    }
}
