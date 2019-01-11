namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class format : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Projects", "Title", c => c.String(maxLength: 200));
            AlterColumn("dbo.Projects", "EntryDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Projects", "EntryDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Projects", "Title", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
