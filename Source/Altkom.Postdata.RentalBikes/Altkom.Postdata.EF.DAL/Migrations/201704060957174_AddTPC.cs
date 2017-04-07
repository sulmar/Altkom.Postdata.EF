namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTPC : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "alt.Dogs",
                c => new
                    {
                        AnimalId = c.Int(nullable: false),
                        Color = c.String(unicode: false),
                        Owner = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
            CreateTable(
                "alt.Horses",
                c => new
                    {
                        AnimalId = c.Int(nullable: false),
                        Color = c.String(unicode: false),
                        Speed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AnimalId);
            
        }
        
        public override void Down()
        {
            DropTable("alt.Horses");
            DropTable("alt.Dogs");
        }
    }
}
