namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeTests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.test2", "TestId", "dbo.tests");
            DropIndex("dbo.test2", new[] { "TestId" });
            DropTable("dbo.test2");
            DropTable("dbo.tests");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        test1 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.test2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Test2 = c.String(),
                        TestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.test2", "TestId");
            AddForeignKey("dbo.test2", "TestId", "dbo.tests", "Id", cascadeDelete: true);
        }
    }
}
