namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfBirthtoPatience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "DateOfBirth", c => c.DateTime(nullable: false));
            Sql("update Patients set DateOfBirth='1994-01-15 22:48:19.060' where id=1");
            Sql("update Patients set DateOfBirth='1992-01-15 22:48:19.060' where id=2");
            Sql("update Patients set DateOfBirth='1997-01-15 22:48:19.060' where id=3");
            Sql("update Patients set DateOfBirth='2004-01-15 22:48:19.060' where id=4");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "DateOfBirth");
        }
    }
}
