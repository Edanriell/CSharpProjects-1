/*Person knownTypeObject =
    new() { Name = "Boris Johnson", DateOfBirth = new(year: 1964, month: 6, day: 19) };*/

/*var anonymouslyTypedObject = new
{
    Name = "Boris Johnson",
    DateOfBirth = new DateTime(year: 1964, month: 6, day: 19)
};*/

// string[] names = new[] { "Michael", "Pam", "Jim", "Dwight", "Angela", "Kevin", "Toby", "Creed" };

// var query = names.Where(name => name.Length > 4).OrderBy(name => name.Length).ThenBy(name => name);

// var query = from name in names where name.Length > 4 orderby name.Length, name select name;

// var query = names.Where(name => name.Length > 4).Skip(80).Take(10);

// var query = (from name in names where name.Length > 4 select name).Skip(80).Take(10);


// FilterAndSort();
// JoinCategoriesAndProducts();
// GroupJoinCategoriesAndProducts();
// AggregateProducts();
// PagingProducts();
// CustomExtensionMethods();
// OutputProductsAsXml();
ProcessSettings();
