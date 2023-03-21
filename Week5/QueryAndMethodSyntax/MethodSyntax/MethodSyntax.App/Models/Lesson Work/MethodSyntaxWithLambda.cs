using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodSyntax.App.Models;

public static class MethodSyntaxWithLambda
{

    public static void FindCustomersWithContactNameBeginningWithChar(NorthwindContext db, char c)
    {
        var customerNames = db.Customers
        .Where(cust => cust.ContactName.StartsWith("A"));

        foreach (var customer in customerNames)
        {
            Console.WriteLine(customer);
        }
    }
    public static void GroupUnitsInStockBySupplierId(NorthwindContext db)
    {
        var products = db.Products
            .Select(c => new {c.UnitsInStock, c.SupplierId})
            .GroupBy(c => c.SupplierId);

        foreach (var product in products)
        {
            foreach (var item in product)
            {
                Console.WriteLine($"{product.Key} --- {item.UnitsInStock}");
            }
        }
    }

    public static void OrderProductsByQuantityPerUnit(NorthwindContext db)
    {
        var quantity = db.Products
            .OrderBy(p => p.QuantityPerUnit)
            .ThenBy(p => p.ReorderLevel);

        foreach (var product in quantity)
        {
            Console.WriteLine(product);
        }
    }
}
