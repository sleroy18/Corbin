namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testproject1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            AddColumn("dbo.ProjectImages", "TestProject_Id", c => c.Int());
            CreateIndex("dbo.ProjectImages", "TestProject_Id");
            AddForeignKey("dbo.ProjectImages", "TestProject_Id", "dbo.TestProjects", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestProjects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectImages", "TestProject_Id", "dbo.TestProjects");
            DropIndex("dbo.TestProjects", new[] { "ApplicationUserId" });
            DropIndex("dbo.ProjectImages", new[] { "TestProject_Id" });
            DropColumn("dbo.ProjectImages", "TestProject_Id");
            DropTable("dbo.TestProjects");
        }
    }
}
