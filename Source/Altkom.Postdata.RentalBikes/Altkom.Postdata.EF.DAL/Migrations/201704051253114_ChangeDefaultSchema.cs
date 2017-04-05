namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDefaultSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Customers", newSchema: "alt");
            MoveTable(name: "dbo.Rentals", newSchema: "alt");
            MoveTable(name: "dbo.Vehicles", newSchema: "alt");
        }
        
        public override void Down()
        {
            MoveTable(name: "alt.Vehicles", newSchema: "dbo");
            MoveTable(name: "alt.Rentals", newSchema: "dbo");
            MoveTable(name: "alt.Customers", newSchema: "dbo");
        }
    }
}
