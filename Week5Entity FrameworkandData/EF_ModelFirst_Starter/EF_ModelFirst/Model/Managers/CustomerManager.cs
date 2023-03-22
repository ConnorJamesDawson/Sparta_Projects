using System;
using System.Linq;

namespace EF_ModelFirst.Model.Managers
{
    public static class CustomerManager
    {

        public static void AddCustomerToDatabase(SouthwindContext db, Customer customerToAdd)
        {
            db.Customers.Add(customerToAdd);
        }

        public static void ReadAllCustomers(SouthwindContext db)
        {
            foreach (var customer in db.Customers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void ReadForSpecificCustomerById(SouthwindContext db, string Id)
        {
            var query = db.Customers
                .Where(c => c.CustomerId == Id);

            foreach (var customer in db.Customers)
            {
                Console.WriteLine(customer);
            }
        }

        public static void UpdateCustomer(SouthwindContext db, Customer customer, string contactName = null, string city = null, string postcode = null)
        {
            Console.WriteLine($"{customer} has be changed to -");
            if (contactName != null || contactName != "") customer.ContactName = contactName;
            if (city != null || city != "") customer.City = city;
            if (postcode != null || postcode != "") customer.PostalCode = postcode;
            Console.WriteLine(customer);

        }

        public static void DeleteCustomerById(SouthwindContext db, string Id)
        {
            var query = db.Customers
            .Where(c => c.CustomerId == Id);

            foreach (var customer in db.Customers)
            {
                Console.WriteLine($"Removed {customer}");
                db.Customers.Remove(customer);
            }
        }

    }
}
