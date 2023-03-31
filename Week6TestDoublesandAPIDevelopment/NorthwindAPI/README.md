# API

## [Bind]

[Bind("SupplierId", "CompanyName", "CoontactTitle", "Country")] Supplier supplier

This line of code means we only care for the json fields that are supplied, all other fields are ignored, it acts like a .Contains("")

## Delete

In order to delete an object without having to delete any other objects that have references to the base object 
            supplier.Products.Select(p => p.SupplierId = null);

Do a .Select() and set the forein key in question to null to avoid having to delete the other values associated with the base object

e.g. If you want to delete a supplier but not the products in the database, you need to go through the Products list and set the supplier foreign key it has to null to get rid of the referencfe between the two resources 