namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAmountToVehicle : DbMigration
    {
        public override void Up()
        {            
            AddColumn("dbo.Vehicles", "Amount", c => c.Decimal(nullable: false, precision: 18, scale: 2, defaultValue: 100));
            
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Amount");
        }
    }
}
