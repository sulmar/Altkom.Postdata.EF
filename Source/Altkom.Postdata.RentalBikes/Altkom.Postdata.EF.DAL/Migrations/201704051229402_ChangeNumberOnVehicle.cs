namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNumberOnVehicle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Number", c => c.String(maxLength: 10, fixedLength: true, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "Number", c => c.String());
        }
    }
}
