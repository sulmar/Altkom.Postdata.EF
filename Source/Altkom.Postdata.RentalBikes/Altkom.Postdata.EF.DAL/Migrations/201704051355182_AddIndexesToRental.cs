namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIndexesToRental : DbMigration
    {
        public override void Up()
        {
            CreateIndex("alt.Rentals", "FromRentalDateTime");
        }
        
        public override void Down()
        {
            DropIndex("alt.Rentals", new[] { "FromRentalDateTime" });
        }
    }
}
