//Place constructor
function Place(place) {
    this.Id = place.Id;
    this.Name = place.Name;
    this.Address = place.Address;
    this.Longitude = place.Longitude;
    this.Latitude = place.Latitude;
    this.Description = place.Description;
    this.User = place.User;
    this.Forecasts = GetPlaceForecasts(this);
    return this;
}