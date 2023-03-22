using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace LoadingTables.App.Models
{
    public class Exercise
    {

        public void Exercise1(NorthwindContext db)
        {
            var query = db.Customers
                .Where(c => c.City == "Paris" || c.City == "London");

            foreach (var customer in query)
            {
                Console.WriteLine($"{customer.CustomerId}: {customer.ContactName} is based at {customer.Address}, {customer.City}");
            }
        }

        public void Exercise2(NorthwindContext db)
        {
            var query = db.Products
                .Where(p => p.QuantityPerUnit!.Contains("bottles"));

            foreach (var product in query)
            {
                Console.WriteLine($"{product.ProductName} is contained in {product.QuantityPerUnit}");
            }
        }

        public void Exercise3(NorthwindContext db)
        {
            var query = db.Products
                .Where(p => p.QuantityPerUnit.Contains("bottles"))
                .Include(p => p.Supplier);

            foreach (var product in query)
            {
                Console.WriteLine($"{product.ProductName} is contained in {product.QuantityPerUnit} and is from {product.Supplier!.CompanyName} who are based in {product.Supplier.Country}");
            }        
        }

        public void Exercise4(NorthwindContext db)
        {
            var query = db.Products
                .Join(db.Products, c => c.CategoryId, s => s.CategoryId, (c, s) => new
                {
                    CategoryName = c,
                    SupplyCount = s.CategoryId
                })
                .GroupBy(c => c.CategoryName);


            foreach (var product in query)
            {
                Console.WriteLine($"{product}");
            }
        }

        public void Exercise5(NorthwindContext db)
        {
            var query = db.Employees;

            foreach (var employee in query)
            {
                Console.WriteLine($"{employee}");
            }
        }

        public void Exercise6(NorthwindContext db)
        {
            var query = db.Orders
                .Where(o => o.Freight > 100 && o.ShipCountry == "USA" || o.ShipCountry == "UK");

            foreach (var order in query)
            {
                Console.WriteLine(order);
            }
        }

    }
}
