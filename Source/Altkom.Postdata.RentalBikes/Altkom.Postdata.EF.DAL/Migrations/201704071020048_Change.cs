namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Change : DbMigration
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
                        Address = p.String(unicode: false),
                        Capacity = p.Byte(),
                        CreateDate = p.DateTime(storeType: "datetime2"),
                        ModifiedDate = p.DateTime(storeType: "datetime2"),
                        RowVersion = p.Binary(),
                    },
                body:
                    @"UPDATE [crm].[Stations]
                      SET [Location_Latitude] = @Location_Latitude, [Location_Longitude] = @Location_Longitude, [Location_Altitude] = @Location_Altitude, [Symbol] = @Symbol, [Name] = @Name, [Address] = @Address, [Capacity] = @Capacity, [CreateDate] = @CreateDate, [ModifiedDate] = @ModifiedDate, [RowVersion] = @RowVersion
                      WHERE ([StationId] = @StationId)"
            );
            
            AlterStoredProcedure(
                "alt.remove_station",
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
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
