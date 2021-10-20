namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userschemachange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emails", "User_Id", "dbo.Users");
            DropIndex("dbo.Emails", new[] { "User_Id" });
            DropColumn("dbo.Emails", "User_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Emails", "User_Id", c => c.Int());
            CreateIndex("dbo.Emails", "User_Id");
            AddForeignKey("dbo.Emails", "User_Id", "dbo.Users", "Id");
        }
    }
}
