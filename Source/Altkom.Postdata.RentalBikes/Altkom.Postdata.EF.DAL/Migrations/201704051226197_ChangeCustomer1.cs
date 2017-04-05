namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomer1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "LastName", c => c.String(maxLength: 50));
        }
    }
}
