namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dobAndlnameAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserLastName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "DOB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "UserFirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UserFirstName", c => c.String());
            DropColumn("dbo.Users", "DOB");
            DropColumn("dbo.Users", "UserLastName");
        }
    }
}
