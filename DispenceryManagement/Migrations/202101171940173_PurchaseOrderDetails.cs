namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PurchaseOrderDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PurchaseCourses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PurchaseDate = c.DateTime(nullable: false),
                        DispenceryItems_Id = c.Int(nullable: false),
                        Patients_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DispenceryItems", t => t.DispenceryItems_Id, cascadeDelete: true)
                .ForeignKey("dbo.Patients", t => t.Patients_Id, cascadeDelete: true)
                .Index(t => t.DispenceryItems_Id)
                .Index(t => t.Patients_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseCourses", "Patients_Id", "dbo.Patients");
            DropForeignKey("dbo.PurchaseCourses", "DispenceryItems_Id", "dbo.DispenceryItems");
            DropIndex("dbo.PurchaseCourses", new[] { "Patients_Id" });
            DropIndex("dbo.PurchaseCourses", new[] { "DispenceryItems_Id" });
            DropTable("dbo.PurchaseCourses");
        }
    }
}
