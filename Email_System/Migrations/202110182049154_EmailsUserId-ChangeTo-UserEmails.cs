namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailsUserIdChangeToUserEmails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "FromUserEmailId", c => c.String(nullable: false));
            AddColumn("dbo.Emails", "ToUserEmailId", c => c.String(nullable: false));
            DropColumn("dbo.Emails", "FromUserId");
            DropColumn("dbo.Emails", "ToUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "ToUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "FromUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Emails", "ToUserEmailId");
            DropColumn("dbo.Emails", "FromUserEmailId");
        }
    }
}
