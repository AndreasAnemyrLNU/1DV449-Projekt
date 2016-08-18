namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfkForecast : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Forecasts", "Place_Id", "dbo.Places");
            DropIndex("dbo.Forecasts", new[] { "Place_Id" });
            RenameColumn(table: "dbo.Forecasts", name: "Place_Id", newName: "PlaceId");
            AlterColumn("dbo.Forecasts", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Forecasts", "PlaceId");
            AddForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forecasts", "PlaceId", "dbo.Places");
            DropIndex("dbo.Forecasts", new[] { "PlaceId" });
            AlterColumn("dbo.Forecasts", "PlaceId", c => c.Int());
            RenameColumn(table: "dbo.Forecasts", name: "PlaceId", newName: "Place_Id");
            CreateIndex("dbo.Forecasts", "Place_Id");
            AddForeignKey("dbo.Forecasts", "Place_Id", "dbo.Places", "Id");
        }
    }
}
