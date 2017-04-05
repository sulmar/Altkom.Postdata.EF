namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCustomer2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Identifier", c => c.String(nullable: false, maxLength: 20, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Identifier", c => c.String());
        }
    }
}
