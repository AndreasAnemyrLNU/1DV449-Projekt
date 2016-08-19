//Category Constructor
function Category(category) {
    this.Id = category.Id;
    this.Name = category.Name;
    this.User = category.User;
    //places generated in ajax call.
    this.Places = GetCategoryPlaces(this);
    return this;
}