namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfknullableForecast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places");
            DropIndex("dbo.Forecasts", new[] { "PlaceId" });
            AlterColumn("dbo.Forecasts", "PlaceId", c => c.Int());
            CreateIndex("dbo.Forecasts", "PlaceId");
            AddForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places");
            DropIndex("dbo.Forecasts", new[] { "PlaceId" });
            AlterColumn("dbo.Forecasts", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Forecasts", "PlaceId");
            AddForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
