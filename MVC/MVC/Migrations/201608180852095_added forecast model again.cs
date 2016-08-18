namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforecastmodelagain : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Forecasts",
                c => new
                    {
                        forecastId = c.Int(nullable: false, identity: true),
                        symbolNumer = c.String(nullable: false),
                        symbolName = c.String(nullable: false),
                        symbolVar = c.String(nullable: false),
                        windDirectionDeg = c.String(nullable: false),
                        windDirectionCode = c.String(nullable: false),
                        windDirectionName = c.String(nullable: false),
                        windSpeedMps = c.String(nullable: false),
                        windSpeedName = c.String(nullable: false),
                        temperatureUnit = c.String(nullable: false),
                        temperatureValue = c.String(nullable: false),
                        temperatureMin = c.String(nullable: false),
                        temperatureMax = c.String(nullable: false),
                        pressureUnit = c.String(nullable: false),
                        pressureValue = c.String(nullable: false),
                        humidityValue = c.String(nullable: false),
                        humidityUnit = c.String(nullable: false),
                        cloudsValue = c.String(nullable: false),
                        cloudsAll = c.String(nullable: false),
                        cloudsUnit = c.String(nullable: false),
                        timeFrom = c.DateTime(nullable: false),
                        timeTo = c.DateTime(nullable: false),
                        Place_Id = c.Int(),
                    })
                .PrimaryKey(t => t.forecastId)
                .ForeignKey("dbo.Places", t => t.Place_Id)
                .Index(t => t.Place_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Forecasts", "Place_Id", "dbo.Places");
            DropIndex("dbo.Forecasts", new[] { "Place_Id" });
            DropTable("dbo.Forecasts");
        }
    }
}
