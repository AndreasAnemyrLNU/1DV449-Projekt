namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testwithfk2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Categories", "App_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "App_Id", c => c.Int(nullable: false));
        }
    }
}
