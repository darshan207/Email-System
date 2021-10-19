namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class composeschema : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AttachmentName = c.String(nullable: false),
                        AttachmentData = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Emails", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Emails", "EmailAttachment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "EmailAttachment", c => c.Binary());
            DropForeignKey("dbo.EmailAttachments", "Id", "dbo.Emails");
            DropIndex("dbo.EmailAttachments", new[] { "Id" });
            DropTable("dbo.EmailAttachments");
        }
    }
}
