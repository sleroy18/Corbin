namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameMyProject : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Projects", newName: "MyProjects");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.MyProjects", newName: "Projects");
        }
    }
}
