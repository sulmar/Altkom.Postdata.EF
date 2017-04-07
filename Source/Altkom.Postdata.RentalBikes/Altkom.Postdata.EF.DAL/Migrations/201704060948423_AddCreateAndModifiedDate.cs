namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCreateAndModifiedDate : DbMigration
    {
        public override void Up()
        {
            AddColumn("alt.Customers", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.Customers", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.People", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.People", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.Rentals", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.Rentals", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.Vehicles", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("alt.Vehicles", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("crm.Stations", "CreateDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("crm.Stations", "ModifiedDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("crm.Stations", "ModifiedDate");
            DropColumn("crm.Stations", "CreateDate");
            DropColumn("alt.Vehicles", "ModifiedDate");
            DropColumn("alt.Vehicles", "CreateDate");
            DropColumn("alt.Rentals", "ModifiedDate");
            DropColumn("alt.Rentals", "CreateDate");
            DropColumn("alt.People", "ModifiedDate");
            DropColumn("alt.People", "CreateDate");
            DropColumn("alt.Customers", "ModifiedDate");
            DropColumn("alt.Customers", "CreateDate");
        }
    }
}
