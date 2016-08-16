namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Placetest2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Longitude", c => c.String());
            AlterColumn("dbo.Places", "Latitude", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Latitude", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Longitude", c => c.String(nullable: false));
        }
    }
}
