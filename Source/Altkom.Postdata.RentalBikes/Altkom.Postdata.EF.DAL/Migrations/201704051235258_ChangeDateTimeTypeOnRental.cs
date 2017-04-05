namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDateTimeTypeOnRental : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "FromRentalDateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Rentals", "ToRentalDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "ToRentalDateTime", c => c.DateTime());
            AlterColumn("dbo.Rentals", "FromRentalDateTime", c => c.DateTime(nullable: false));
        }
    }
}
