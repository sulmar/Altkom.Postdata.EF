namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyStoreProcedure : DbMigration
    {
        public override void Up()
        {                        
            // CreateStoredProcedure("dbo.uspAddCustomer", p=>new { date = p.d)
        }
        
        public override void Down()
        {
            // DropStoredProcedure()
        }
    }
}
