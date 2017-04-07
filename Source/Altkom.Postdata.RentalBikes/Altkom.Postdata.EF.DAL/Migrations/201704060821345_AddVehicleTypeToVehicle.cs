namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleTypeToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("alt.Vehicles", "VehicleType", c => c.String(nullable: false, maxLength: 128));

            Sql("UPDATE alt.Vehicles SET VehicleType = left(Discriminator, 1)");

            DropColumn("alt.Vehicles", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("alt.Vehicles", "Discriminator", c => c.String(nullable: false, maxLength: 128));

            Sql("UPDATE alt.Vehicles SET Discriminator = case VehicleType when 'S' then 'Scooter' when 'B' then 'Bike' end");

            DropColumn("alt.Vehicles", "VehicleType");
        }
    }
}
