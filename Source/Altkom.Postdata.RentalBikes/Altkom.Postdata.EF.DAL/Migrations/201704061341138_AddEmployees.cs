namespace Altkom.Postdata.EF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployees : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "alt.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "alt.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(unicode: false),
                        LastName = c.String(unicode: false),
                        Salary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreateDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        ModifiedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.EmployeeId);
            
            CreateTable(
                "alt.EmployeeProjects",
                c => new
                    {
                        Employee_EmployeeId = c.Int(nullable: false),
                        Project_ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Employee_EmployeeId, t.Project_ProjectId })
                .ForeignKey("alt.Employees", t => t.Employee_EmployeeId, cascadeDelete: true)
                .ForeignKey("alt.Projects", t => t.Project_ProjectId, cascadeDelete: true)
                .Index(t => t.Employee_EmployeeId)
                .Index(t => t.Project_ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("alt.EmployeeProjects", "Project_ProjectId", "alt.Projects");
            DropForeignKey("alt.EmployeeProjects", "Employee_EmployeeId", "alt.Employees");
            DropIndex("alt.EmployeeProjects", new[] { "Project_ProjectId" });
            DropIndex("alt.EmployeeProjects", new[] { "Employee_EmployeeId" });
            DropTable("alt.EmployeeProjects");
            DropTable("alt.Employees");
            DropTable("alt.Projects");
        }
    }
}
