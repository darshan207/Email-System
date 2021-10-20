namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailAttachmentSchemaRemove : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EmailAttachments", "Id", "dbo.Emails");
            DropIndex("dbo.EmailAttachments", new[] { "Id" });
            AddColumn("dbo.Emails", "AttachmentName", c => c.String());
            AddColumn("dbo.Emails", "AttachmentData", c => c.Binary());
            DropTable("dbo.EmailAttachments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmailAttachments",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AttachmentName = c.String(nullable: false),
                        AttachmentData = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Emails", "AttachmentData");
            DropColumn("dbo.Emails", "AttachmentName");
            CreateIndex("dbo.EmailAttachments", "Id");
            AddForeignKey("dbo.EmailAttachments", "Id", "dbo.Emails", "Id");
        }
    }
}
