using QuerySyntax.App.Models;
using System;

namespace QuerySyntax.Models;

public class Program
{
    static void Main()
    {
        using (var db = new NorthwindContext())
        {
            var records = //Sets up the query
                from product in db.Products
                group product by product.SupplierId into newgroup
                orderby newgroup.Sum(c => c.UnitsInStock) descending
                select new
                {
                    SupplierID = newgroup.Key,
                    UnitsInStock = newgroup.Sum(c => c.UnitsInStock)
                };

/*                select new  //Anonamus type
                {
                    Customer = customer.CompanyName, 
                    Country = customer.City
                };*/

            foreach(var row in records) // Executes the query
            {
                Console.WriteLine(row);
            }

        }
    }
}