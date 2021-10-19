namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Attachmenttypeadded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "AttachmentType", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "AttachmentType", c => c.Binary());
        }
    }
}
