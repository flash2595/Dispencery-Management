namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDispenceryTypeTableNew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DispenceryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DispenceryItems", "dispenceryTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.DispenceryItems", "dispenceryType_Id", c => c.Int());
            CreateIndex("dbo.DispenceryItems", "dispenceryType_Id");
            AddForeignKey("dbo.DispenceryItems", "dispenceryType_Id", "dbo.DispenceryTypes", "Id");

            Sql("Insert into DispenceryTypes (Name) values ('Anti-Bacterial')");
            Sql("Insert into DispenceryTypes (Name) values ('Anti-Mosquitue')");
            Sql("Insert into DispenceryTypes (Name) values ('Appetite')");
            Sql("Insert into DispenceryTypes (Name) values ('Blood Pressure')");
            Sql("Insert into DispenceryTypes (Name) values ('Fever')");
            Sql("Insert into DispenceryTypes (Name) values ('Injection Liquid')");
            Sql("Insert into DispenceryTypes (Name) values ('Pain-Killer')");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DispenceryItems", "dispenceryType_Id", "dbo.DispenceryTypes");
            DropIndex("dbo.DispenceryItems", new[] { "dispenceryType_Id" });
            DropColumn("dbo.DispenceryItems", "dispenceryType_Id");
            DropColumn("dbo.DispenceryItems", "dispenceryTypeId");
            DropTable("dbo.DispenceryTypes");
        }
    }
}
