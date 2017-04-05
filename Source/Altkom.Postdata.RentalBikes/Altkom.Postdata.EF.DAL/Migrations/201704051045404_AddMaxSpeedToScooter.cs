namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaxSpeedToScooter : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "MaxSpeed", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "MaxSpeed");
        }
    }
}
