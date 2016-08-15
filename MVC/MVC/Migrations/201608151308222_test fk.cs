namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testfk : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apps", "CategoriId", c => c.Int());
            AddColumn("dbo.Categories", "ApplicationId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "ApplicationId");
            DropColumn("dbo.Apps", "CategoriId");
        }
    }
}
