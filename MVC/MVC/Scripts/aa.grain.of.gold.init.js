var State =
{
    Apps: []
}
//End

//Mechanism to save state in localstorage
function autoSaveToLocalStorage() {
    localStorage.setItem("State.Apps", JSON.stringify(State.Apps));
    console.info("State was now saved into localstorage...")

    setTimeout(autoSaveToLocalStorage, 1000)
}
// End    

init();

function init()
{
    GetApps();
    autoSaveToLocalStorage();
}
      
function GetApps()
{
    $.get("/apps/GetApps", function (data) {
        JsonApps2AppsApps(data)

        var appBtns = [];
        $.each(State.Apps, function (i, app) {
            appBtns.push(renderAppBtn(app));     
        })     
        $("#apps-template").html(renderAppPanel(appBtns));
    
       
        $.each(State.Apps, function (i, app) {
            console.log(app);
            $("#" + `${replacaSpacesWithUnderscore(app.AppName)}_${app.Id}`).on("click", function (e) {
                alert();
            })
            //$(`#${app.AppName}_${app.Id}"`).on('click', function () {
            //    alert(app.AppName);
            //})
        });
        
    });            

}

function GetAppCategories(app)
{
    $.get("/apps/GetAppCategories/" + app.Id, function(data){
        app.Categories = JsonAppCategories2AppCategories(data);
    });
}

function GetCategoryPlaces(category)
{
    $.get("/apps/GetCategoryPlaces/" + category.Id, function (data) {
        category.Places = JsonCategoryPlaces2CategoryPlaces(data)
    });
}

function GetPlaceForecasts(place) {
    $.get("/apps/GetPlaceForecasts/" + place.Id, function (data) {
        place.Forecasts = JsonPlaceForecasts2PlaceForecasts(data)
    });
}


