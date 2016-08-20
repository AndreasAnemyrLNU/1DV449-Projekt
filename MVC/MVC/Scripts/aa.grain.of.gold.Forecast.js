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

Forecast.prototype.GetWeatherSymbol = function () {
    return (`http://openweathermap.org/img/w/${this.symbolVar}.png`);
};

Forecast.prototype.GetWindDirectionCode = function () {
    return this.windDirectionCode.toLowerCase();
};

Forecast.prototype.GetTimeFrom = function () {
    var hour = new Date(this.timeFrom).getHours();
    if (hour < 10)
        hour = "0" + hour;
    var min = new Date(this.timeFrom).getHours();
    if (min < 10)
        min = "0" + min;
    return `${hour}:${min}`
};

Forecast.prototype.GetDate = function () {
    return new Date(this.timeFrom).getDate();
};

Forecast.prototype.GetMonth = function () {
    return new Date(this.timeFrom).getMonth().toLocaleString();
};