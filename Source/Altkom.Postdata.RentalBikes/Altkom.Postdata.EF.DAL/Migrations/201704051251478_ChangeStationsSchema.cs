namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStationsSchema : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Stations", newSchema: "crm");
        }
        
        public override void Down()
        {
            MoveTable(name: "crm.Stations", newSchema: "dbo");
        }
    }
}
