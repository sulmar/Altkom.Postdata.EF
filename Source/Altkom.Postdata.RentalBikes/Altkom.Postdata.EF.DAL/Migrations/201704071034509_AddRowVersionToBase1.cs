namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRowVersionToBase1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("alt.Customers", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("alt.People", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("alt.Projects", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("alt.Employees", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("alt.Rentals", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("alt.Vehicles", "RowVersion", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
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
                        RowVersion_Original = p.Binary(maxLength: 8, fixedLength: true, storeType: "rowversion"),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE (([StationId] = @StationId) AND (([RowVersion] = @RowVersion_Original) OR ([RowVersion] IS NULL AND @RowVersion_Original IS NULL)))
                      
                      SELECT t0.[RowVersion]
                      FROM [crm].[Stations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[StationId] = @StationId"
            );
            
        }
        
        public override void Down()
        {
            DropColumn("alt.Vehicles", "RowVersion");
            DropColumn("alt.Rentals", "RowVersion");
            DropColumn("alt.Employees", "RowVersion");
            DropColumn("alt.Projects", "RowVersion");
            DropColumn("alt.People", "RowVersion");
            DropColumn("alt.Customers", "RowVersion");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
