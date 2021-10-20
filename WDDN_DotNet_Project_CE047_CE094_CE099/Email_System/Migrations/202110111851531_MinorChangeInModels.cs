namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MinorChangeInModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "UserEmailService_Id", c => c.Int(nullable: false));
            AddColumn("dbo.UserEmailServices", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Emails", "EmailSubject", c => c.String());
            AlterColumn("dbo.Emails", "EmailText", c => c.String(nullable: false));
            AlterColumn("dbo.Emails", "EmailAttachment", c => c.Binary());
            AlterColumn("dbo.Users", "UserEmailId", c => c.String(nullable: false));
            CreateIndex("dbo.UserEmailServices", "User_Id");
            CreateIndex("dbo.Emails", "UserEmailService_Id");
            AddForeignKey("dbo.UserEmailServices", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "UserEmailService_Id", "dbo.UserEmailServices", "Id", cascadeDelete: true);
            DropColumn("dbo.Emails", "UserMailServiceId");
            DropColumn("dbo.UserEmailServices", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserEmailServices", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "UserMailServiceId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Emails", "UserEmailService_Id", "dbo.UserEmailServices");
            DropForeignKey("dbo.UserEmailServices", "User_Id", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "UserEmailService_Id" });
            DropIndex("dbo.UserEmailServices", new[] { "User_Id" });
            AlterColumn("dbo.Users", "UserEmailId", c => c.String(nullable: false));
            AlterColumn("dbo.Emails", "EmailAttachment", c => c.Binary());
            AlterColumn("dbo.Emails", "EmailText", c => c.String(nullable: false));
            AlterColumn("dbo.Emails", "EmailSubject", c => c.String());
            DropColumn("dbo.UserEmailServices", "User_Id");
            DropColumn("dbo.Emails", "UserEmailService_Id");
        }
    }
}
