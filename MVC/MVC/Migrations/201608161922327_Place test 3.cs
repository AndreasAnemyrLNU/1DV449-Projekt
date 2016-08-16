namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Placetest3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Longitude", c => c.String(nullable: false));
            AlterColumn("dbo.Places", "Latitude", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Latitude", c => c.String());
            AlterColumn("dbo.Places", "Longitude", c => c.String());
            AlterColumn("dbo.Places", "Address", c => c.String());
        }
    }
}
