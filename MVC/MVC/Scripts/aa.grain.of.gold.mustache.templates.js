//App Stuff start
function renderAppPanel(htmlAppBtns) {
    var html = ""
	$.each(htmlAppBtns, function (i, htmlAppBtn) {
	    html += htmlAppBtn
	})
	return "<div>" + html + "</div>"
}

function renderAppBtn(app) {
	var tpl = `<btn id="${replacaSpacesWithUnderscore(app.AppName)}_${app.Id}" class='btn btn-primary'>{{AppName}}</btn>`;
	return Mustache.to_html(tpl, app)
}
//App End

//Category Stuff Start
function renderCategoryBtn(category) {
	var tpl = `<btn id="${category.Name}_${category.Id}" class='btn btn-primary'>{{Name}}</btn>`;
	return Mustache.to_html(tpl, app)}
//Category End