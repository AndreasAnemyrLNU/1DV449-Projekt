function App(app) {
    this.Id = app.Id;
	this.AppName = app.AppName;
	this.Categories = GetAppCategories(this);
	return this;
}