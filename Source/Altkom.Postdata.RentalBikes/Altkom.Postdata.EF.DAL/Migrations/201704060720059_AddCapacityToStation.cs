namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCapacityToStation : DbMigration
    {
        public override void Up()
        {
            AddColumn("crm.Stations", "Capacity", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("crm.Stations", "Capacity");
        }
    }
}
