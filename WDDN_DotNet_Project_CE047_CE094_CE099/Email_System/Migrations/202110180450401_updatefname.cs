namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatefname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserFirstName", c => c.String());
            DropColumn("dbo.Users", "FirstName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            DropColumn("dbo.Users", "UserFirstName");
        }
    }
}
