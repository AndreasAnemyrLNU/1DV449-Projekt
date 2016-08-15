namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removefks : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Apps", "CategoriId");
            DropColumn("dbo.Categories", "ApplicationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Categories", "ApplicationId", c => c.Int());
            AddColumn("dbo.Apps", "CategoriId", c => c.Int());
        }
    }
}
