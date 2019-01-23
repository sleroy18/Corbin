namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class switchimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "imageStream", c => c.Binary());
            DropColumn("dbo.Images", "URL");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Images", "URL", c => c.String());
            DropColumn("dbo.Images", "imageStream");
        }
    }
}
