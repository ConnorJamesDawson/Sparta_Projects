using System;
using System.Collections.Generic;

namespace EF_ModelFirst.Model;

public static class SeedDatabase
{

    public static void SeedCustomers(SouthwindContext db)
    {
        var customers = new List<Customer>()
            {
                new Customer
                {
                    CustomerId = "A",
                    ContactName = "Eliza",
                    City = "London",
                    PostalCode = "L1 5TA",
                    Country = "UK"
                },
                new Customer
                {
                    CustomerId = "B",
                    ContactName = "Tom",
                    City = "London",
                    PostalCode = "L1 7TD",
                    Country = "UK"
                },
                new Customer
                {
                    CustomerId = "C",
                    ContactName = "Harry",
                    City = "Sheldford",
                    PostalCode = "S22 5AD",
                    Country = "UK"
                },
                new Customer
                {
                    CustomerId = "D",
                    ContactName = "Mary",
                    City = "Blithe",
                    PostalCode = "BL12 5GA",
                    Country = "UK"
                },
                new Customer
                {
                    CustomerId = "E",
                    ContactName = "Jack",
                    City = "Sheffiled",
                    PostalCode = "S17 5TA",
                    Country = "UK"
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

    public static void SeedOrder(SouthwindContext db)
    {

        var orders = new List<Order>()
        {
            new Order
            {
                CustomerId = "A",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today.AddDays(3),
                ShipCountry = "UK",
                //Customer = ,
                //OrderDetails = ,
            },
            new Order
            {
                CustomerId = "B",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today.AddDays(5),
                ShipCountry = "UK",
                //Customer = ,
                //OrderDetails = ,
            },
            new Order
            {
                CustomerId = "C",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today.AddDays(1),
                ShipCountry = "UK",
                //Customer = ,
                //OrderDetails = ,
            },
            new Order
            {
                CustomerId = "D",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today.AddDays(3),
                ShipCountry = "UK",
                //Customer = ,
                //OrderDetails = ,
            },
            new Order
            {
                CustomerId = "A",
                OrderDate = DateTime.Today,
                ShippedDate = DateTime.Today.AddDays(11),
                ShipCountry = "UK",
                //Customer = ,
                //OrderDetails = ,
            }
        };
        foreach (var order in orders)
        {

            db.Orders.Add(order);
        }
        db.SaveChanges();
        foreach (var order in db.Customers)
        {
            Console.WriteLine(order);
        }
    }
    public static void SeedOrderDetails(SouthwindContext db)
    {
        var orderDetails = new List<OrderDetail>()
        {
            new OrderDetail
            {
                OrderId = 1,
                UnitPrice = 10.00m,
                Quantity = 3,
                Discount = 0.05f
            },
            new OrderDetail
            {
                OrderId = 2,
                UnitPrice = 10.50m,
                Quantity = 2,
                Discount = 0.01f
            },
            new OrderDetail
            {
                OrderId = 3,
                UnitPrice = 13.00m,
                Quantity = 5,
                Discount = 0.15f
            },
            new OrderDetail
            {
                OrderId = 4,
                UnitPrice = 11.00m,
                Quantity = 13,
                Discount = 0.25f
            },
            new OrderDetail
            {
                OrderId = 5,
                UnitPrice = 17.00m,
                Quantity = 3,
                Discount = 0.05f
            },
        };
        foreach (var detials in orderDetails)
        {

            db.OrderDetails.Add(detials);
        }
        db.SaveChanges();
        foreach (var detials in orderDetails)
        {
            Console.WriteLine(detials);
        }
    }

}
