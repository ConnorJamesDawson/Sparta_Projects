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
                from customer in db.Customers
                where customer.City == "London" || customer.City == "Paris"
                select customer;

            foreach(var row in records) // Executes the query
            {
                Console.WriteLine(row);
            }

        }
    }
}