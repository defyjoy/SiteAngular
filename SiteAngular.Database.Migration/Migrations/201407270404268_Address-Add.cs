namespace SiteAngular.Database.Migration.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        AddressGuid = c.Guid(nullable: false, identity: true),
                        StudentGuid = c.Guid(nullable: false),
                        Building = c.String(),
                        Street = c.String(),
                        LandMark = c.String(),
                        District = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.AddressGuid)
                .ForeignKey("dbo.Students", t => t.StudentGuid, cascadeDelete: true)
                .Index(t => t.StudentGuid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Address", "StudentGuid", "dbo.Students");
            DropIndex("dbo.Address", new[] { "StudentGuid" });
            DropTable("dbo.Address");
        }
    }
}
