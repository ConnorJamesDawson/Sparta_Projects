using LoadingTables.App.Models;
using Microsoft.EntityFrameworkCore;

namespace LoadingTables.App;

internal class Program
{
    static void Main()
    {
        using (var db = new NorthwindContext())
        {
            #region .Include()
            var orderQuery = db.Orders
                .Where(o => o.Freight > 750)
                .Include(o => o.Customer)
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product);

            /*            foreach (var order in orderQuery)
                        {
                            Console.WriteLine($"Order {order.OrderId} was made by {order.Customer!.CompanyName}");
                            foreach (var detail in order.OrderDetails)
                            {
                                Console.WriteLine(
                                    $"\t ProductId: {detail.ProductId} - " +
                                    $"Product: {detail.Product.ProductName} - " +
                                    $"Quantity: {detail.Quantity}");
                            }
                        }*/
            #endregion

            #region .Join()

            var cityQuery = db.Customers
                .Join(
                db.Suppliers,
                c => c.City,
                s => s.City,
                (c, s) => new
                {
                    Customer = c.ContactName,
                    CustomerCompany = c.CompanyName,
                    Supplier = c.ContactName,
                    SupplierCompany = s.CompanyName
                }
                );

            foreach (var result in cityQuery)
            {
                Console.WriteLine($"Customer {result.Customer} at {result.CustomerCompany} " +
                $"lives in the same city as {result.Supplier} at {result.SupplierCompany}");
            }

            #endregion
        }
    }
}