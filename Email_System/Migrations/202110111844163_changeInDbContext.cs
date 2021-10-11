namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeInDbContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserMailServiceId = c.Int(nullable: false),
                        ToUserId = c.Int(nullable: false),
                        EMailSubject = c.String(),
                        EMailText = c.String(nullable: false),
                        EMailAttachment = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEmailServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "UserName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "UserPass", c => c.String(nullable: false));
            AddColumn("dbo.Users", "UserEMailId", c => c.String(nullable: false));
            DropColumn("dbo.Users", "uname");
            DropColumn("dbo.Users", "pass");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "pass", c => c.String());
            AddColumn("dbo.Users", "uname", c => c.String());
            DropColumn("dbo.Users", "UserEMailId");
            DropColumn("dbo.Users", "UserPass");
            DropColumn("dbo.Users", "UserName");
            DropTable("dbo.UserEmailServices");
            DropTable("dbo.Emails");
        }
    }
}
