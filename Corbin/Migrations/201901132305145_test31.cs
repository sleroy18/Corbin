namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test31 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.test3",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        teststr = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.test3");
        }
    }
}
