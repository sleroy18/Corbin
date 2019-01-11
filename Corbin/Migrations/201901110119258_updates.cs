namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updates : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Images", "Project_Id", "dbo.Projects");
            DropForeignKey("dbo.Videos", "Project_Id", "dbo.Projects");
            DropIndex("dbo.Images", new[] { "Project_Id" });
            DropIndex("dbo.Videos", new[] { "Project_Id" });
            DropColumn("dbo.Images", "ProjectId");
            DropColumn("dbo.Videos", "ProjectId");
            RenameColumn(table: "dbo.Images", name: "Project_Id", newName: "ProjectId");
            RenameColumn(table: "dbo.Videos", name: "Project_Id", newName: "ProjectId");
            AddColumn("dbo.Images", "Description", c => c.String(maxLength: 100));
            AddColumn("dbo.Images", "URL", c => c.String());
            AddColumn("dbo.Videos", "Description", c => c.String());
            AddColumn("dbo.Videos", "URL", c => c.String());
            AlterColumn("dbo.Images", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Images", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Videos", "ProjectId", c => c.Int(nullable: false));
            AlterColumn("dbo.Videos", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Images", "ProjectId");
            CreateIndex("dbo.Videos", "ProjectId");
            AddForeignKey("dbo.Images", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Videos", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            DropColumn("dbo.Images", "Name");
            DropColumn("dbo.Images", "Location");
            DropColumn("dbo.Videos", "Location");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Videos", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Images", "Location", c => c.String(nullable: false));
            AddColumn("dbo.Images", "Name", c => c.String(nullable: false, maxLength: 100));
            DropForeignKey("dbo.Videos", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Images", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Videos", new[] { "ProjectId" });
            DropIndex("dbo.Images", new[] { "ProjectId" });
            AlterColumn("dbo.Videos", "ProjectId", c => c.Int());
            AlterColumn("dbo.Videos", "ProjectId", c => c.String());
            AlterColumn("dbo.Videos", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Images", "ProjectId", c => c.Int());
            AlterColumn("dbo.Images", "ProjectId", c => c.String());
            DropColumn("dbo.Videos", "URL");
            DropColumn("dbo.Videos", "Description");
            DropColumn("dbo.Images", "URL");
            DropColumn("dbo.Images", "Description");
            RenameColumn(table: "dbo.Videos", name: "ProjectId", newName: "Project_Id");
            RenameColumn(table: "dbo.Images", name: "ProjectId", newName: "Project_Id");
            AddColumn("dbo.Videos", "ProjectId", c => c.String());
            AddColumn("dbo.Images", "ProjectId", c => c.String());
            CreateIndex("dbo.Videos", "Project_Id");
            CreateIndex("dbo.Images", "Project_Id");
            AddForeignKey("dbo.Videos", "Project_Id", "dbo.Projects", "Id");
            AddForeignKey("dbo.Images", "Project_Id", "dbo.Projects", "Id");
        }
    }
}
