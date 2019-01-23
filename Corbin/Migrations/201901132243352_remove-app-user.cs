namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeappuser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMainImage = c.Boolean(nullable: false),
                        Description = c.String(),
                        imageStream = c.Binary(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
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
            
            CreateTable(
                "dbo.ProjectVideos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMainVideo = c.Boolean(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        URL = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectVideos", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ProjectImages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectVideos", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            DropIndex("dbo.ProjectImages", new[] { "ProjectId" });
            DropTable("dbo.ProjectVideos");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectImages");
        }
    }
}
