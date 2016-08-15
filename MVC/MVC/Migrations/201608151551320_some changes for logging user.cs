namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechangesforlogginguser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "User", c => c.String());
            AddColumn("dbo.Places", "User", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "User");
            DropColumn("dbo.Categories", "User");
        }
    }
}
