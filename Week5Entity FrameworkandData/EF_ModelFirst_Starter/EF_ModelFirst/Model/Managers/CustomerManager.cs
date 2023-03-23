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

        public static Customer ReadForSpecificCustomerById(SouthwindContext db, string Id)
        {
            var query = db.Customers
                .Where(c => c.CustomerId == Id);

            foreach (var customer in query)
            {
                return customer;
            }
            return null;
        }

        public static bool UpdateCustomerById(SouthwindContext db, string customerId, string contactName = null, string city = null, string postcode = null)
        {
            var customer = ReadForSpecificCustomerById(db, customerId);
            if (customer == null) return false;
            Console.WriteLine($"{customer} has be changed to -");
            if (contactName != null || contactName != "")
            {
                customer.ContactName = contactName;
            }

            if (city != null || city != "")
            {
                customer.City = city;
            }

            if (postcode != null || postcode != "")
            {
                customer.PostalCode = postcode;
            }

            Console.WriteLine(customer);
            return true;
        }

        public static bool DeleteCustomerById(SouthwindContext db, string Id)
        {
            var customer = ReadForSpecificCustomerById(db, Id);

            int beforeCount = db.Customers.Count();
            if(customer != null)
            {
                Console.WriteLine($"Removed {customer}");

                db.Customers.Remove(customer);

                db.SaveChanges();
            }
            if (beforeCount != db.Customers.Count())
            {
                return true;
            }
            else
                return false;
        }

    }
}
