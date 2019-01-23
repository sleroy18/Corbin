namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Videos", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Images", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ApplicationUserId" });
            DropIndex("dbo.Videos", new[] { "ProjectId" });
            DropTable("dbo.Images");
            DropTable("dbo.Projects");
            DropTable("dbo.Videos");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMainVideo = c.Boolean(nullable: false),
                        Name = c.String(maxLength: 100),
                        Description = c.String(),
                        URL = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Description = c.String(),
                        EntryDate = c.DateTime(nullable: false),
                        LastUpdated = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsMainImage = c.Boolean(nullable: false),
                        Description = c.String(maxLength: 100),
                        imageStream = c.Binary(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Videos", "ProjectId");
            CreateIndex("dbo.Projects", "ApplicationUserId");
            CreateIndex("dbo.Images", "ProjectId");
            AddForeignKey("dbo.Videos", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ApplicationUserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Images", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
