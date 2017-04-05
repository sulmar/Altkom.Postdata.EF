namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAltitudeToLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stations", "Location_Altitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stations", "Location_Altitude");
        }
    }
}
