var State =
{
    CurrentApp: {},
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

    $("body").on("click", function (e) {



        $.each(State.CurrentApp.Categories, function (i, category) {
            $("#categories-template").html(renderCategories(State.CurrentApp.Categories));
        })

        //User clicked in category section
        if (e.target.getAttribute("data-model") === 'category') {


            //Find clicked category in current used app by State.CurrentApp
                $.each(State.CurrentApp.Categories, function (i, category) {



                    if (e.target.id === `${replacaSpacesWithUnderscore(category.Name)}_${category.Id}`) {

                        console.log(category);


                        $("#places-template").html(renderPlaces(category.Places));
                    };
                });
        };
    });
}
      
function GetApps()
{
    $.get("/apps/GetApps", function (data) {
        JsonApps2AppsApps(data)

        var appBtns = [];
        $.each(State.Apps, function (i, app) {
            appBtns.push(renderAppBtn(app));     
        })     

        //Add to DOM (mustache)
        $("#apps-template").html(renderAppPanel(appBtns));
    
       
        //Init events for app btns...
        //When user clicks button app is saved in State.CurrentApp!
        $.each(State.Apps, function (i, app) {

            $("#" + `${replacaSpacesWithUnderscore(app.AppName)}_${app.Id}`).on("click", function () {
                //Set curretn App!
                State.CurrentApp = app;
            });

        });
        
    });            

}

/*          //Todo fix selected for btns!!!!
                $(this).removeClass("btn-primary")
                $(this).addClass("btn-info")
*/



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


