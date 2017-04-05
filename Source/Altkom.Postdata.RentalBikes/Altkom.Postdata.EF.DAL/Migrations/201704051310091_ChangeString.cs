namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("alt.Customers", "FirstName", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("alt.Customers", "LastName", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("alt.Customers", "PhoneNumber", c => c.String(unicode: false));
            AlterColumn("alt.Customers", "Email", c => c.String(unicode: false));
            AlterColumn("alt.Vehicles", "Size", c => c.String(unicode: false));
            AlterColumn("alt.Vehicles", "Color", c => c.String(unicode: false));
            AlterColumn("crm.Stations", "Symbol", c => c.String(unicode: false));
            AlterColumn("crm.Stations", "Name", c => c.String(unicode: false));
            AlterColumn("crm.Stations", "Address", c => c.String(unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("crm.Stations", "Address", c => c.String());
            AlterColumn("crm.Stations", "Name", c => c.String());
            AlterColumn("crm.Stations", "Symbol", c => c.String());
            AlterColumn("alt.Vehicles", "Color", c => c.String());
            AlterColumn("alt.Vehicles", "Size", c => c.String());
            AlterColumn("alt.Customers", "Email", c => c.String());
            AlterColumn("alt.Customers", "PhoneNumber", c => c.String());
            AlterColumn("alt.Customers", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("alt.Customers", "FirstName", c => c.String(maxLength: 50));
        }
    }
}
