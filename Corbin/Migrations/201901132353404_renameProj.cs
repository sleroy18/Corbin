namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class renameProj : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MyProjects", newName: "Projects");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Projects", newName: "MyProjects");
        }
    }
}
