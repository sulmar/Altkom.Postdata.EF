namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyScript : DbMigration
    {
        public override void Up()
        {
            SqlResource("Altkom.Postdata.EF.DAL.Scripts.201704051325251_UpdateCustomer_Up.sql");
        }
        
        public override void Down()
        {
            SqlResource("Altkom.Postdata.EF.DAL.Scripts.201704051325251_UpdateCustomer_Down.sql");
        }
    }
}
