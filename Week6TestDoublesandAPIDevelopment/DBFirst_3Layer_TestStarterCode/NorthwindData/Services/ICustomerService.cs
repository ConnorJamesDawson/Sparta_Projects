using System.Collections.Generic;

namespace NorthwindData.Services
{
    public interface ICustomerService
    {
        List<Customer> GetCustomerList();
        Customer GetCustomerById(string customerId);
        void CreateCustomer(Customer customer);
        void SaveCustomerChanges();
        void RemoveCustomer(Customer customer);
    }
}
