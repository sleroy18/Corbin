namespace Corbin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class length : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.RegisterEmails", new[] { "Email" });
            AlterColumn("dbo.RegisterEmails", "Email", c => c.String(maxLength: 200));
            CreateIndex("dbo.RegisterEmails", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.RegisterEmails", new[] { "Email" });
            AlterColumn("dbo.RegisterEmails", "Email", c => c.String(maxLength: 30));
            CreateIndex("dbo.RegisterEmails", "Email", unique: true);
        }
    }
}
