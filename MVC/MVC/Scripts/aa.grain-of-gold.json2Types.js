//Json parse functions returning real arrays with "typed" objects.... 
function JsonApps2AppsApps(json) {
    incoming = JSON.parse(json);
    //console.info("Apps parsed to generic objects...");
    //console.info(incoming);
    var appsNowApps = [];

    $.each(incoming, function (i, app) {
        app.UpdateCategories = true;
        appsNowApps.push(new App(app))
    })
    //console.info("Apps is real apps now!");
    //console.info(appsNowApps);
    //Later accessible through object State (State.Apps)
    State.Apps = appsNowApps;
}

function JsonAppCategories2AppCategories(json) {
    incoming = JSON.parse(json);
    //onsole.info("Categories parsed to generic objects...");
    //console.info(incoming);
    var appCategoriesNowCategories = [];

    $.each(incoming, function (i, category) {
        appCategoriesNowCategories.push(new Category(category))
    })
    //console.info("Categories is real categories now!");
    //console.info(appCategoriesNowCategories);
    //Later accessible through object State (State.App.Categories)
    return appCategoriesNowCategories;
}

function JsonCategoryPlaces2CategoryPlaces(json) {
    incoming = JSON.parse(json);
    //onsole.info("Categories parsed to generic objects...");
    //console.info(incoming);
    var categoryPlacesNowCategoryPlaces = [];

    $.each(incoming, function (i, place) {
        categoryPlacesNowCategoryPlaces.push(new Place(place))
    })
    //console.info("Categories is real categories now!");
    //console.info(appCategoriesNowCategories);
    //Later accessible through object State (State.App.Categories)
    return categoryPlacesNowCategoryPlaces;
}

function JsonPlaceForecasts2PlaceForecasts(json) {
    incoming = JSON.parse(json);
    //onsole.info("Categories parsed to generic objects...");
    //console.info(incoming);
    var placeForecastsNowPlaceForecasts = [];

    $.each(incoming, function (i, forecast) {
        placeForecastsNowPlaceForecasts.push(new Forecast(forecast))
    })
    //console.info("Categories is real categories now!");
    //console.info(appCategoriesNowCategories);
    //Later accessible through object State (State.App.Categories)
    return placeForecastsNowPlaceForecasts;
} 
// End

app = new App()
