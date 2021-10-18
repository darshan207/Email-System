namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "FirstName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Emails", "UserId");
        }
    }
}
