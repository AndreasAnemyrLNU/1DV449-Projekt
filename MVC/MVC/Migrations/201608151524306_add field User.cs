namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addfieldUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apps", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Apps", "User");
        }
    }
}
