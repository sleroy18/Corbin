namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.test2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test2 = c.String(),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tests", t => t.TestId, cascadeDelete: true)
                .Index(t => t.TestId);
            
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        test1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.test2", "TestId", "dbo.tests");
            DropIndex("dbo.test2", new[] { "TestId" });
            DropTable("dbo.tests");
            DropTable("dbo.test2");
        }
    }
}
