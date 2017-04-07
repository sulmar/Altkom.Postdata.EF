namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoredProceduresToStation : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "alt.Station_Insert",
                p => new
                    {
                        Location_Latitude = p.Double(),
                        Location_Longitude = p.Double(),
                        Location_Altitude = p.Double(),
                        Symbol = p.String(unicode: false),
                        Name = p.String(unicode: false),
                        Address = p.String(unicode: false),
                        Capacity = p.Byte(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"INSERT [crm].[Stations]([Location_Latitude], [Location_Longitude], [Location_Altitude], [Symbol], [Name], [Address], [Capacity], [CreateDate], [ModifiedDate])
                      VALUES (@Location_Latitude, @Location_Longitude, @Location_Altitude, @Symbol, @Name, @Address, @Capacity, @CreateDate, @ModifiedDate)
                      
                      DECLARE @StationId int
                      SELECT @StationId = [StationId]
                      FROM [crm].[Stations]
                      WHERE @@ROWCOUNT > 0 AND [StationId] = scope_identity()
                      
                      SELECT t0.[StationId]
                      FROM [crm].[Stations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[StationId] = @StationId"
            );
            
            CreateStoredProcedure(
                "alt.Station_Update",
                p => new
                    {
                        StationId = p.Int(),
                        Location_Latitude = p.Double(),
                        Location_Longitude = p.Double(),
                        Location_Altitude = p.Double(),
                        Symbol = p.String(unicode: false),
                        Name = p.String(unicode: false),
                        Address = p.String(unicode: false),
                        Capacity = p.Byte(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE ([StationId] = @StationId)"
            );
            
            CreateStoredProcedure(
                "alt.Station_Delete",
                p => new
                    {
                        StationId = p.Int(),
                    },
                body:
                    @"DELETE [crm].[Stations]
                      WHERE ([StationId] = @StationId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("alt.Station_Delete");
            DropStoredProcedure("alt.Station_Update");
            DropStoredProcedure("alt.Station_Insert");
        }
    }
}
