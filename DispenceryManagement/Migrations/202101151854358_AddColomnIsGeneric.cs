namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColomnIsGeneric : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispenceryItems", "IsGeneric", c => c.Boolean(nullable: false));
            Sql("update DispenceryItems set IsGeneric='True' where id in (2,4,6,8,10,12)");
            Sql("update DispenceryItems set IsGeneric='False' where id in (1,3,5,7,9,11)");
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispenceryItems", "IsGeneric");
        }
    }
}
