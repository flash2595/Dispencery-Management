namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableDispenceryItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DispenceryItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DispenceryItemName = c.String(),
                        DispenceryItemType = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Lysol','Anti-Bacterial')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Dattol','Anti-Bacterial')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Disperene','Pain-Killer')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Dolo 650','Pain-Killer')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Crocine','Pain-Killer')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Mortin','Anti-Mosquitue')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Disperene','Pain-Killer')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Adderall','Pain-Killer')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Amglong','Blood Pressure')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Baclofen','Injection Liquid')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('Easprin','Fever')");
            Sql("insert into DispenceryItems (DispenceryItemName,DispenceryItemType) values ('phentermine','Appetite')");
        }

        public override void Down()
        {
            DropTable("dbo.DispenceryItems");
        }
    }
}
