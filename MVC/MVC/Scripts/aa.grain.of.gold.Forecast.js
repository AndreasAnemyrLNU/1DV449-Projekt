//Forecast constructor
function Forecast(forecast) {
    this.symbolNumer = forecast.symbolNumer;
    this.symbolName = forecast.SymbolName;
    this.symbolVar = forecast.symbolVar;
    this.windDirectionDeg = forecast.windDirectionDeg;
    this.windDirectionCode = forecast.windDirectionCode;
    this.windDirectionName = forecast.windDirectionName;
    this.windSpeedMps = forecast.windSpeedMps;
    this.windSpeedName = forecast.windSpeedName;
    this.temperatureUnit = forecast.temperatureUnit;
    this.temperatureValue = forecast.temperturValue;
    this.temperatureMin = forecast.temperatureMin;
    this.temperatureMax = forecast.temperatureMax;
    this.pressureUnit = forecast.pressureUnit;
    this.pressureValue = forecast.pressureValue;
    this.humidityValue = forecast.humidityValue;
    this.humidityUnit = forecast.humidityUnit;
    this.cloudsValue = forecast.cloudsValue;
    this.cloudsAll = forecast.cloudsAll;
    this.cloudsUnit = forecast.cloudsUnit;
    this.timeFrom = forecast.timeFrom;
    this.timeTo = forecast.timeTo;
    this.placeId = forecast.PlaceId;
    return this;
}