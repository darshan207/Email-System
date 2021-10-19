namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attachmentfileaddfiletype : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "AttachmentType", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Emails", "AttachmentType");
        }
    }
}
