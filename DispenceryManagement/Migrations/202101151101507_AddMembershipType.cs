namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipType : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Patients", "MembershipTypeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Patients", "MembershipTypeId");
            AddForeignKey("dbo.Patients", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Patients", new[] { "MembershipTypeId" });
            DropColumn("dbo.Patients", "MembershipTypeId");
            DropTable("dbo.MembershipTypes");
        }
    }
}
