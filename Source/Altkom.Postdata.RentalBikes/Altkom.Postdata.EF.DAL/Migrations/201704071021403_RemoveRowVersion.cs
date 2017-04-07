namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveRowVersion : DbMigration
    {
        public override void Up()
        {
            DropColumn("alt.Customers", "RowVersion");
            DropColumn("alt.People", "RowVersion");
            DropColumn("alt.Projects", "RowVersion");
            DropColumn("alt.Employees", "RowVersion");
            DropColumn("alt.Rentals", "RowVersion");
            DropColumn("alt.Vehicles", "RowVersion");
            DropColumn("crm.Stations", "RowVersion");
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
                      
                      SELECT t0.[StationId]
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
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE ([StationId] = @StationId)"
            );
            
        }
        
        public override void Down()
        {
            AddColumn("crm.Stations", "RowVersion", c => c.Binary());
            AddColumn("alt.Vehicles", "RowVersion", c => c.Binary());
            AddColumn("alt.Rentals", "RowVersion", c => c.Binary());
            AddColumn("alt.Employees", "RowVersion", c => c.Binary());
            AddColumn("alt.Projects", "RowVersion", c => c.Binary());
            AddColumn("alt.People", "RowVersion", c => c.Binary());
            AddColumn("alt.Customers", "RowVersion", c => c.Binary());
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
