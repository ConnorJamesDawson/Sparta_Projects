using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_ModelFirst.Model.Managers;

namespace EF_ModelFirst;

public static class HandleInput
{
    static string input;
    public static void ReadInput(SouthwindContext db)
    {

        input = Console.ReadLine();

        switch(input)
        {
            case "1":
                HandleInput_AddCustomer(db);
                break;
            case "2":
                HandleInput_UpdateCustomer(db);
                break;
            case "3":
                HandleInput_DeleteCustomerById(db);
                break;
            case "4":
                HandleInput_PrintAllCustomers(db);
                break;
        }
    }

    public static void HandleInput_AddCustomer(SouthwindContext db)
    {
        Console.WriteLine("Please input the Id of the new customer (The Id can be a mixture of letters and numbers):");
        string id = Console.ReadLine();
        Console.WriteLine("Please input the Name of the new customer:");
        string name = Console.ReadLine();
        Console.WriteLine("Please input the name of the City where the new customer is:");
        string city = Console.ReadLine();
        Console.WriteLine("Please input the Postcode of the new customer:");
        string postcode = Console.ReadLine();

        Customer newCust = new Customer() { CustomerId = id, ContactName = name, City = city, PostalCode = postcode };

        CustomerManager.AddCustomerToDatabase(db, newCust);
    }

    public static void HandleInput_UpdateCustomer(SouthwindContext db)
    {
        HandleInput_PrintAllCustomers(db);
        Console.WriteLine("     ---    ");
        Console.WriteLine("Please input the Id of the customer you want to update:");
        string id = Console.ReadLine();

        var query = db.Customers
            .Where(c => c.CustomerId == id);

        foreach (var customer in query)
        {
            Console.WriteLine($"Name: {customer.ContactName}, City: {customer.City}, Postcose: {customer.PostalCode}");
            Console.WriteLine("If you do not want to change a field just press enter");
            Console.WriteLine("     ---     ");
            Console.WriteLine("Please input the Name of the new customer:");
            string name = Console.ReadLine();
            Console.WriteLine("Please input the name of the City where the new customer is:");
            string city = Console.ReadLine();
            Console.WriteLine("Please input the Postcode of the new customer:");
            string postcode = Console.ReadLine();

            CustomerManager.UpdateCustomer(db, customer, name, city, postcode);
        }
    }

    public static void HandleInput_DeleteCustomerById(SouthwindContext db)
    {
        HandleInput_PrintAllCustomers(db);
        Console.WriteLine("Please input the Id of the Customer you want to remove from the database");
        string id = Console.ReadLine();

        CustomerManager.DeleteCustomerById(db, id);
    }

    public static void HandleInput_PrintAllCustomers(SouthwindContext db)
    {
        CustomerManager.ReadAllCustomers(db);
    }

}
