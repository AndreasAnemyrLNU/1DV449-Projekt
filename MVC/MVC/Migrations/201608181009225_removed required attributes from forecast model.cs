namespace MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedrequiredattributesfromforecastmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Forecasts", "symbolNumer", c => c.String());
            AlterColumn("dbo.Forecasts", "symbolName", c => c.String());
            AlterColumn("dbo.Forecasts", "symbolVar", c => c.String());
            AlterColumn("dbo.Forecasts", "windDirectionDeg", c => c.String());
            AlterColumn("dbo.Forecasts", "windDirectionCode", c => c.String());
            AlterColumn("dbo.Forecasts", "windDirectionName", c => c.String());
            AlterColumn("dbo.Forecasts", "windSpeedMps", c => c.String());
            AlterColumn("dbo.Forecasts", "windSpeedName", c => c.String());
            AlterColumn("dbo.Forecasts", "temperatureUnit", c => c.String());
            AlterColumn("dbo.Forecasts", "temperatureValue", c => c.String());
            AlterColumn("dbo.Forecasts", "temperatureMin", c => c.String());
            AlterColumn("dbo.Forecasts", "temperatureMax", c => c.String());
            AlterColumn("dbo.Forecasts", "pressureUnit", c => c.String());
            AlterColumn("dbo.Forecasts", "pressureValue", c => c.String());
            AlterColumn("dbo.Forecasts", "humidityValue", c => c.String());
            AlterColumn("dbo.Forecasts", "humidityUnit", c => c.String());
            AlterColumn("dbo.Forecasts", "cloudsValue", c => c.String());
            AlterColumn("dbo.Forecasts", "cloudsAll", c => c.String());
            AlterColumn("dbo.Forecasts", "cloudsUnit", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Forecasts", "cloudsUnit", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "cloudsAll", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "cloudsValue", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "humidityUnit", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "humidityValue", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "pressureValue", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "pressureUnit", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "temperatureMax", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "temperatureMin", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "temperatureValue", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "temperatureUnit", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "windSpeedName", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "windSpeedMps", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "windDirectionName", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "windDirectionCode", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "windDirectionDeg", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "symbolVar", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "symbolName", c => c.String(nullable: false));
            AlterColumn("dbo.Forecasts", "symbolNumer", c => c.String(nullable: false));
        }
    }
}
