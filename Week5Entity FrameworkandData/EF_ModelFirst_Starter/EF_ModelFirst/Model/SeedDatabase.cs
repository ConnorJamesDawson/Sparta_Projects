using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_ModelFirst.Model;

public static class SeedDatabase
{

    public static void Seed(SouthwindContext db)
    {
        var customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId = "A",
                    ContactName = "Eliza",
                    City = "London",
                    PostalCode = "L1 5TA"
                },
                new Customer
                {
                    CustomerId = "B",
                    ContactName = "Tom",
                    City = "London",
                    PostalCode = "L1 7TD"
                },
                new Customer
                {
                    CustomerId = "C",
                    ContactName = "Harry",
                    City = "Sheldford",
                    PostalCode = "S22 5AD"
                },
                new Customer
                {
                    CustomerId = "D",
                    ContactName = "Mary",
                    City = "Blithe",
                    PostalCode = "BL12 5GA"
                },
                new Customer
                {
                    CustomerId = "E",
                    ContactName = "Jack",
                    City = "Sheffiled",
                    PostalCode = "S17 5TA"
                }
            };
        foreach (var customer in customers)
        {

            db.Customers.Add(customer);
        }
        db.SaveChanges();
        foreach (var customer in db.Customers)
        {
            System.Console.WriteLine(customer);
        }
    }

}
