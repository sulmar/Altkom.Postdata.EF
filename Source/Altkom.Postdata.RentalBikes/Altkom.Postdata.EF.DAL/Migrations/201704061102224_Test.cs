namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropColumn("alt.Rentals", "BikeId");
        }
        
        public override void Down()
        {
            AddColumn("alt.Rentals", "BikeId", c => c.Int(nullable: false));
        }
    }
}
