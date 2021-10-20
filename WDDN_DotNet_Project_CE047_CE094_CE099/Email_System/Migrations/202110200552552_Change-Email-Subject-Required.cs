namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeEmailSubjectRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Emails", "EmailSubject", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Emails", "EmailSubject", c => c.String());
        }
    }
}
