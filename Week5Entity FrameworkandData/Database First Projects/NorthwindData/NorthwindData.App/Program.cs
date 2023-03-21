using NorthwindData.App.Models;

namespace NorthwindData.App;

internal class Program
{
    static void Main()
    {

        using (var db = new NorthwindContext())
        {
            foreach (var customers in db.Customers)
            {
                if(customers.City == "London")
                {
                    //Console.WriteLine(customers);
                }
            }
            Customer customer = new Customer()
            {
                CustomerId = "BLUEE",
                ContactName = "I'm Blue",
                CompanyName = "Dabadee",
                City = "Grimsby"
            };

            //db.Customers.Add(customer); // Added but not actually inserted to db
            //db.SaveChanges(); //Commits info to server

            var selectedCustomer = db.Customers.Find("BLUEE");
            Console.WriteLine(selectedCustomer);

            selectedCustomer.City = "Barry";

            Console.WriteLine(selectedCustomer);

            db.Customers.Remove(selectedCustomer);

            db.SaveChanges();
        }

        
        
    }
}