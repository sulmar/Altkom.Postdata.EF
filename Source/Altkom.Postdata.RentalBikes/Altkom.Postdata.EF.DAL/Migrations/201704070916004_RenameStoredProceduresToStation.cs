namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStoredProceduresToStation : DbMigration
    {
        public override void Up()
        {
            RenameStoredProcedure(name: "alt.Station_Insert", newName: "add_station");
            RenameStoredProcedure(name: "alt.Station_Update", newName: "modify_station");
            RenameStoredProcedure(name: "alt.Station_Delete", newName: "remove_station");
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "alt.remove_station", newName: "Station_Delete");
            RenameStoredProcedure(name: "alt.modify_station", newName: "Station_Update");
            RenameStoredProcedure(name: "alt.add_station", newName: "Station_Insert");
        }
    }
}
