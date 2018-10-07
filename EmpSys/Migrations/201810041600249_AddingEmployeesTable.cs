namespace EmpSys.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingEmployeesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Designation = c.String(nullable: false, maxLength: 255),
                        ContactId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contacts", t => t.ContactId, cascadeDelete: true)
                .Index(t => t.ContactId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ContactId", "dbo.Contacts");
            DropIndex("dbo.Employees", new[] { "ContactId" });
            DropTable("dbo.Contacts");
            DropTable("dbo.Employees");
        }
    }
}
