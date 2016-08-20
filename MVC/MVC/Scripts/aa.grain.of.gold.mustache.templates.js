//App Stuff start
function renderAppPanel(htmlAppBtns) {
    var html = ""
	$.each(htmlAppBtns, function (i, htmlAppBtn) {
	    html += htmlAppBtn
	})
	return "<div>" + html + "</div>"
}

function renderAppBtn(app) {
	var tpl = `<btn id="${replacaSpacesWithUnderscore(app.AppName)}_${app.Id}" class='btn btn-block btn-primary-ui-app'>{{AppName}}</btn>`;
	return Mustache.to_html(tpl, app)
}
//App End

//Category Stuff Start
function renderCategories(categories) {
    var html = ""
    $.each(categories, function (i, category) {
    	html += renderCategoryBtn(category)
    })
    return "<div>" + html + "</div>"
}

function renderCategoryBtn(category) {
	var tpl = `<btn id="${replacaSpacesWithUnderscore(category.Name)}_${category.Id}" class='btn btn-block btn-primary-ui-category' data-model='category'>{{Name}}</btn>`;
	return Mustache.to_html(tpl, category)
}
//Category End

//Plac Stuff Start
function renderPlaces(places) {
	var html = ""
	$.each(places, function (i, place) {
		html += renderPlaceBtn(place)
	})
	return "<div>" + html + "</div>"
}

function renderPlaceBtn(place) {
	var tpl = `<btn id="${replacaSpacesWithUnderscore(place.Name)}_${place.Id}" class='btn btn-sm btn-primary-ui' data-model='place'>{{Name}}</btn>`;
	return Mustache.to_html(tpl, place)
}

function renderPlaceContent(place) {

	try {
		if(!place instanceof Place)
			throw new Error("the function renderPlaceContent() takes only obj of Type Place!")
	} catch (err) {
		console.warn(err.message)
	}

	var tpl =
    `<h6 class="text-info"><strong >Namn: {{Name}}</strong><h6>` +
	`<h6 class="text-info"><strong >Info: {{Description}}</strong><h6>` +
	`<h6 class="text-info"><strong >Sparad av: {{User}}</strong><h6>` +
    `<div class="jumbotron">` +
        `<h3 class="text-center" >Minnesmärkets väderdata idag!</h3>` +
        `{{#Forecasts}}{{>Forecast}}{{/Forecasts}}` +
    `</div>`;
                

    //Forecasts
	var partials =
    {
    	Forecast:
            `<div id="container-weather-data">` +
            `<div class="well well-with-padding col-xs-12 col-sm-4 col-md-3 col-lg-2">` +
                `<div class="panel-body">` +
                    `<h4 class=text-center>{{temperatureMin}} &#8451</h4>` +
                    `<img src={{GetWeatherSymbol}} />` +
    	            //Compass Start
                    `<div class="compass">` +
                        `<div class="direction">` +
                            `<p>{{windDirectionCode}}<span>{{windSpeedMps}} Mps</span></p>` +
                        `</div>` +
                        `<div class="arrow {{GetWindDirectionCode}}"></div>` +
                    `</div>` +
                    //Compas End
                    `<h5 class="access-time text-center">Från kl {{GetTimeFrom}}</h5>` +
                    `<h5 class="access-time text-center">Dag {{GetDate}}/{{GetMonth}}</h5>` +
                `</div>` +
    	    `</div>` +
            `</div`
    }

	return Mustache.to_html(tpl, place, partials)

}
//Place End