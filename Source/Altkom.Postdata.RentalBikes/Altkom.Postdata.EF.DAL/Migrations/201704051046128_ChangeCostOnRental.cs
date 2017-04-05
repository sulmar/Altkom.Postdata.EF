namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCostOnRental : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rentals", "Cost", c => c.Decimal(precision: 18, scale: 2));

            Sql("UPDATE dbo.Rentals SET Cost = 1");
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rentals", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));

            Sql("UPDATE dbo.Rentals SET Cost = 0");
        }
    }
}
