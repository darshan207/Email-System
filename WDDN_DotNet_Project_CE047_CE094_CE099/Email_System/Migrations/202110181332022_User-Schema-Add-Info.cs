namespace Email_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserSchemaAddInfo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "UserFirstName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "UserLastName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "DOB", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DOB");
            DropColumn("dbo.Users", "UserLastName");
            DropColumn("dbo.Users", "UserFirstName");
        }
    }
}
