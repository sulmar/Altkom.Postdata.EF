namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Spatial;
    
    public partial class AddDbGeographyToBike : DbMigration
    {
        public override void Up()
        {
            AddColumn("alt.Vehicles", "Location", c => c.Geography());
        }
        
        public override void Down()
        {
            DropColumn("alt.Vehicles", "Location");
        }
    }
}
