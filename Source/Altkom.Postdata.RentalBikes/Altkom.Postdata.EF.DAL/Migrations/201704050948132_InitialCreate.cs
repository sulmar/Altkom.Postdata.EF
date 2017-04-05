namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Identifier = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Rentals",
                c => new
                    {
                        RentalId = c.Int(nullable: false, identity: true),
                        FromRentalDateTime = c.DateTime(nullable: false),
                        ToRentalDateTime = c.DateTime(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bike_VehicleId = c.Int(),
                        FromStation_StationId = c.Int(),
                        Rentee_CustomerId = c.Int(),
                        ToStation_StationId = c.Int(),
                    })
                .PrimaryKey(t => t.RentalId)
                .ForeignKey("dbo.Vehicles", t => t.Bike_VehicleId)
                .ForeignKey("dbo.Stations", t => t.FromStation_StationId)
                .ForeignKey("dbo.Customers", t => t.Rentee_CustomerId)
                .ForeignKey("dbo.Stations", t => t.ToStation_StationId)
                .Index(t => t.Bike_VehicleId)
                .Index(t => t.FromStation_StationId)
                .Index(t => t.Rentee_CustomerId)
                .Index(t => t.ToStation_StationId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        BikeType = c.Int(),
                        Size = c.String(),
                        Color = c.String(),
                        Capacity = c.Double(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.VehicleId);
            
            CreateTable(
                "dbo.Stations",
                c => new
                    {
                        StationId = c.Int(nullable: false, identity: true),
                        Location_Latitude = c.Double(nullable: false),
                        Location_Longitude = c.Double(nullable: false),
                        Symbol = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.StationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "ToStation_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "Rentee_CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Rentals", "FromStation_StationId", "dbo.Stations");
            DropForeignKey("dbo.Rentals", "Bike_VehicleId", "dbo.Vehicles");
            DropIndex("dbo.Rentals", new[] { "ToStation_StationId" });
            DropIndex("dbo.Rentals", new[] { "Rentee_CustomerId" });
            DropIndex("dbo.Rentals", new[] { "FromStation_StationId" });
            DropIndex("dbo.Rentals", new[] { "Bike_VehicleId" });
            DropTable("dbo.Stations");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Rentals");
            DropTable("dbo.Customers");
        }
    }
}
