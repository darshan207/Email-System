namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "uname", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "pass", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "pass", c => c.String());
            AlterColumn("dbo.Users", "uname", c => c.String());
        }
    }
}
