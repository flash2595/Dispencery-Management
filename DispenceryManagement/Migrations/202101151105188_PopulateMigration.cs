namespace DispenceryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMigration : DbMigration
    {
        public override void Up()
        {
            Sql("Insert Into MembershipTypes (Id,DiscountRate) values (1,0)");
            Sql("Insert Into MembershipTypes (Id,DiscountRate) values (2,10)");
        }
        
        public override void Down()
        {
        }
    }
}
