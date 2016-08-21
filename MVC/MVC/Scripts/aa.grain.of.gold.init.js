var State =
{
    CurrentPlace: null,
    CurrentApp: {},
    Apps: []
}
//End

//This just simulates a slow writeprocess....
function wait(ms) {
    var start = new Date().getTime();
    var end = start;
    while (end < start + ms) {
        end = new Date().getTime();
    }
}

function appStatusOk() {
    $(`#status`).removeClass(`app-status-unsaved`);
    $(`#status`).addClass(`app-status-ok`);
}

function appStatusUnsaved() {
    $(`#status`).removeClass(`app-status-ok`);
    $(`#status`).addClass(`app-status-unsaved`);
}

//TODO this both logiq and view. Refactor it later!!!!
function appConnectionQuality(value) {

    //DRY I KNOW.... - but i keep it simle....
    if (value < 1500)
        $(`#connection-quality-backend`).text(`Bad Connection!`);
    if (value < 950)
        $(`#connection-quality-backend`).text(`| (Response - ${value}/ms)`);
    if (value < 920)
        $(`#connection-quality-backend`).text(`||| (Response - ${value}/ms)`);
    if (value < 800)
        $(`#connection-quality-backend`).text(`||||| (Response - ${value}/ms)`);
    if (value < 700)
        $(`#connection-quality-backend`).text(`||||||| (Response - ${value}/ms)`);
    if (value < 600)
        $(`#connection-quality-backend`).text(`||||||||| (Response - ${value}/ms)`);
    if (value < 500)
        $(`#connection-quality-backend`).text(`||||||||||| (Response - ${value}/ms)`);
    if (value < 150)
        $(`#connection-quality-backend`).text(`|||||||||||| (Response - ${value}/ms)`);
    if (value < 120)
        $(`#connection-quality-backend`).text(`|||||||||||||| (Response - ${value}/ms)`);
    if (value < 90)
        $(`#connection-quality-backend`).text(`|||||||||||||||| (Response - ${value}/ms)`);
    if (value < 70)
        $(`#connection-quality-backend`).text(`|||||||||||||||||| (Response - ${value}/ms)`);
    if(value < 50)
        $(`#connection-quality-backend`).text(`|||||||||||||||||||| (Response - ${value}/ms)`);
}

var i = 10
//Mechanism to save state in localstorage
function autoSaveToLocalStorage() {

    try {

        if (i == 0) {
            throw new Error("Browser unable to save data!!!...");
        }
        localStorage.setItem("State", JSON.stringify(State));
        console.info(`State was now saved (for the ${i} time), into localstorage...`);
        appStatusOk();
        i--;
    } catch (err) {
        appStatusUnsaved();
        console.warn(err.message);
    }

    setTimeout(autoSaveToLocalStorage, 5000)
}
// End    

init();

function init()
{
    //Connection test!
    (function DecideConnectionQuality() {

        var time = new Date();

        $.get("/", function (data) {
            console.log(time.getMilliseconds());
        });

        appConnectionQuality(time.getMilliseconds());

        setTimeout(DecideConnectionQuality, 2500)
    })();

    GetApps();
    autoSaveToLocalStorage();

    $("body").on("click", function (e) {

        $.each(State.CurrentApp.Categories, function (i, category) {
            $("#categories-template").html(renderCategories(State.CurrentApp.Categories));
            //Reset places container becaus app is clicked...
            $("#places-template").html(renderPlaces(""));

        })

        //User clicked in categories section
        if (e.target.getAttribute("data-model") === 'category') {

            //Find clicked category in current used app by State.CurrentApp
            $.each(State.CurrentApp.Categories, function (i, category) {
                if (e.target.id === `${replacaSpacesWithUnderscore(category.Name)}_${category.Id}`) {
                    $("#places-template").html(renderPlaces(category.Places));
                };
            });
        };

        //User clicked in places section
        if (e.target.getAttribute("data-model") === 'place') {

            //Find clicked place in current used app by recursive searching in State.CurrentApp. 
            //State.CurrentApp.Categories-- > Category.Places-- > Place
            $.each(State.CurrentApp.Categories, function (i, category) {
                $.each(category.Places, function (i, place) {
                    if (e.target.id === `${replacaSpacesWithUnderscore(place.Name)}_${place.Id}`) {
                        //Found Place (model), Save state first...
                        State.CurrentPlace = place;
                        console.log(State.CurrentPlace);
                        //Now we can render, State is used for easy adding marker to map...
                        try {
                                if (typeof renderPlaceContent == 'function') { 
                                        $("#place-content-template").html(renderPlaceContent(place)); 
                                    }
                                else {
                                    throw new Error("function renderPlaceContent does not exist. Create it!")
                                }
                        }catch(err){
                            console.warn(err)
                        }
                    };
                });
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


