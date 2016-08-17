namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Placeaddpropdescr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Description", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Description");
        }
    }
}
