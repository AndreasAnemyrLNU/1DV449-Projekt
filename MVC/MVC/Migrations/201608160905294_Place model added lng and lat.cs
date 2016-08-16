namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Placemodeladdedlngandlat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "Longitude", c => c.String(nullable: false));
            AddColumn("dbo.Places", "Latitude", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Latitude");
            DropColumn("dbo.Places", "Longitude");
        }
    }
}
