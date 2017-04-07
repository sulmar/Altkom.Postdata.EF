namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowVersion : DbMigration
    {
        public override void Up()
        {
            AddColumn("crm.Stations", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AlterStoredProcedure(
                "alt.add_station",
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
                      
                      SELECT t0.[StationId], t0.[RowVersion]
                      FROM [crm].[Stations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[StationId] = @StationId"
            );
            
            AlterStoredProcedure(
                "alt.modify_station",
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
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE (([StationId] = @StationId) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [crm].[Stations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[StationId] = @StationId"
            );
            
            AlterStoredProcedure(
                "alt.remove_station",
                p => new
                    {
                        StationId = p.Int(),
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"DELETE [crm].[Stations]
                      WHERE (([StationId] = @StationId) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("crm.Stations", "RowVersion");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
