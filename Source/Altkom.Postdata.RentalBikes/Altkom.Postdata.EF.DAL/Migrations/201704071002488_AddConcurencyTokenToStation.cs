namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConcurencyTokenToStation : DbMigration
    {
        public override void Up()
        {
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
                        Name_Original = p.String(unicode: false),
                        Address = p.String(unicode: false),
                        Capacity = p.Byte(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate
                      WHERE (([StationId] = @StationId) AND (([Name] = @Name_Original) OR ([Name] IS NULL AND @Name_Original IS NULL)))"
            );
            
            AlterStoredProcedure(
                "alt.remove_station",
                p => new
                    {
                        StationId = p.Int(),
                        Name_Original = p.String(unicode: false),
                    },
                body:
                    @"DELETE [crm].[Stations]
                      WHERE (([StationId] = @StationId) AND (([Name] = @Name_Original) OR ([Name] IS NULL AND @Name_Original IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
