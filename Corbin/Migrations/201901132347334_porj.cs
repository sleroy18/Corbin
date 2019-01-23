namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class porj : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Projects", newName: "MyProjects");
            DropTable("dbo.test3");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.test3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        teststr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            RenameTable(name: "dbo.MyProjects", newName: "Projects");
        }
    }
}
