namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeInEmail : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEmailServices", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Emails", "UserEmailService_Id", "dbo.UserEmailServices");
            DropIndex("dbo.UserEmailServices", new[] { "User_Id" });
            DropIndex("dbo.Emails", new[] { "UserEmailService_Id" });
            AddColumn("dbo.Emails", "FromUserId", c => c.Int(nullable: false));
            AddColumn("dbo.Emails", "Is_Inbox", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "Is_Sent", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "Is_FromUser_Starred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "Is_ToUser_Starred", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "Is_FromUser_Delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "Is_ToUser_Delete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Emails", "User_Id", c => c.Int());
            CreateIndex("dbo.Emails", "User_Id");
            AddForeignKey("dbo.Emails", "User_Id", "dbo.Users", "Id");
            DropColumn("dbo.Emails", "UserEmailService_Id");
            DropTable("dbo.UserEmailServices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserEmailServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Emails", "UserEmailService_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.Emails", "User_Id", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "User_Id" });
            DropColumn("dbo.Emails", "User_Id");
            DropColumn("dbo.Emails", "Is_ToUser_Delete");
            DropColumn("dbo.Emails", "Is_FromUser_Delete");
            DropColumn("dbo.Emails", "Is_ToUser_Starred");
            DropColumn("dbo.Emails", "Is_FromUser_Starred");
            DropColumn("dbo.Emails", "Is_Sent");
            DropColumn("dbo.Emails", "Is_Inbox");
            DropColumn("dbo.Emails", "FromUserId");
            CreateIndex("dbo.Emails", "UserEmailService_Id");
            CreateIndex("dbo.UserEmailServices", "User_Id");
            AddForeignKey("dbo.Emails", "UserEmailService_Id", "dbo.UserEmailServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserEmailServices", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
        }
    }
}
