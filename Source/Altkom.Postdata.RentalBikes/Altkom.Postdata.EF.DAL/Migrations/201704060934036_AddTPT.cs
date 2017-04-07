namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTPT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "alt.People",
                c => new
                    {
                        PersonId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "alt.Woman",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        LikesColor = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("alt.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
            CreateTable(
                "alt.Men",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        Hobby = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.PersonId)
                .ForeignKey("alt.People", t => t.PersonId)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("alt.Men", "PersonId", "alt.People");
            DropForeignKey("alt.Woman", "PersonId", "alt.People");
            DropIndex("alt.Men", new[] { "PersonId" });
            DropIndex("alt.Woman", new[] { "PersonId" });
            DropTable("alt.Men");
            DropTable("alt.Woman");
            DropTable("alt.People");
        }
    }
}
