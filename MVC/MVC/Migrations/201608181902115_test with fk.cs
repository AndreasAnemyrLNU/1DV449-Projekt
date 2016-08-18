namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testwithfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "App_Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "App_Id");
        }
    }
}
