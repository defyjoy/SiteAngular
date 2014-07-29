namespace SiteAngular.Database.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentTableAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentGuid = c.Guid(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(),
                        Address = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Phone = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.StudentGuid);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
        }
    }
}
