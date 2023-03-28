using Microsoft.EntityFrameworkCore;
using NorthwindData;
using NorthwindData.Services;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace NorthwindTests
{
    internal class CustomerServiceTests
    {
        private CustomerService _sut;
        private NorthwindContext _context;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var options = new DbContextOptionsBuilder<NorthwindContext>()
                .UseInMemoryDatabase("Example_DB")
                .Options;
            _context = new NorthwindContext(options);
            _sut = new CustomerService(_context);

            SeedDatabase();
            _context.SaveChanges();
        }

        [SetUp]
        public void SetUp()
        {
            _context.Customers.RemoveRange(_context.Customers);
            SeedDatabase();
            _context.SaveChanges();
        }

        [Test]
        public void GivenAValidId_GetCustomerById_ReturnsTheCorrectCustomer()
        {
            var result = _sut.GetCustomerById("TOZER");
            Assert.That(result, Is.TypeOf<Customer>());
            Assert.That(result.ContactName, Is.EqualTo("Laura Tozer"));
            Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(result.City, Is.EqualTo("London"));
        }

        [Test]
        public void GivenANewCustomer_CreateCustomer_AddsItToTheDatabase()
        {
            // Arrange
            var numberOfCustomersBefore = _context.Customers.Count();
            var newCustomer = new Customer
            {
                CustomerId = "BEAR",
                ContactName = "Martin Beard",
                CompanyName = "Sparta Global",
                City = "Rome"
            };

            // Act
            _sut.CreateCustomer(newCustomer);
            var numberOfCustomersAfter = _context.Customers.Count();
            var result = _sut.GetCustomerById("BEAR");

            // Assert
            Assert.That(numberOfCustomersBefore + 1, Is.EqualTo(numberOfCustomersAfter));

            Assert.That(result, Is.TypeOf<Customer>());
            Assert.That(result.ContactName, Is.EqualTo("Martin Beard"));
            Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));
            Assert.That(result.City, Is.EqualTo("Rome"));
        }

        [Test]
        public void GetCustomerList_ReturnsAllTheCustomers()
        {
            // Act
            var result = _sut.GetCustomerList();
            // Assert
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result, Is.InstanceOf<List<Customer>>());
        }

        [Test]
        public void GivenACustomer_Remove_RemovesThemFromTheDatabase()
        {
            // Arrange
            var newCustomer = new Customer
            {
                CustomerId = "BEAR",
                ContactName = "Martin Beard",
                CompanyName = "Sparta Global",
                City = "Rome"
            };
            _context.Add(newCustomer);
            _context.SaveChanges();

            var numberOfCustomersBefore = _context.Customers.Count();

            // Act
            _sut.RemoveCustomer(newCustomer);
            // Assert
            Assert.That(
                numberOfCustomersBefore - 1,
                Is.EqualTo(_context.Customers.Count())
            );
            var customerInDb = _context.Customers.Find("BEAR");
            Assert.That(customerInDb, Is.Null);
        }

        private void SeedDatabase()
        {
            _context.Customers.Add(
                new Customer
                {
                    CustomerId = "WINDR",
                    ContactName = "Philip Windridge",
                    CompanyName = "Sparta Global",
                    City = "Birmingham"
                });
            _context.Customers.Add(
                new Customer
                {
                    CustomerId = "TOZER",
                    ContactName = "Laura Tozer",
                    CompanyName = "Sparta Global",
                    City = "London"
                });
        }
    }
}
