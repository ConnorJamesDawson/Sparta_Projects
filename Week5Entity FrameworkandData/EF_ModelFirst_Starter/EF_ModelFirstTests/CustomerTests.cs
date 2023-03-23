using EF_ModelFirst;
using EF_ModelFirst.Model.Managers;

namespace EF_ModelFirstTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // remove test entry in DB if present
            using (var db = new SouthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheNumberOfCustomersIncreasesBy1()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA",
                Country = "UK"
            };
            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();
                Assert.That(db.Customers.Count(), Is.EqualTo(6));
            }
        }

        [Test]
        public void WhenANewCustomerIsAdded_TheirDetailsAreCorrect()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();
                var query = db.Customers
                    .Where(c => c.CustomerId == sutCustomer.CustomerId);
                foreach (var customer in query)
                {
                    Assert.That(customer.ContactName, Is.EqualTo(sutCustomer.ContactName));
                    Assert.That(customer.City, Is.EqualTo(sutCustomer.City));
                    Assert.That(customer.PostalCode, Is.EqualTo(sutCustomer.PostalCode));

                }
            }
        }

        [Test]
        public void WhenRetrievingCustomers_CustomerListIsRightLength()
        {
            using (var db = new SouthwindContext())
            {
                var query = db.Customers;

                Assert.That(query.Count, Is.EqualTo(5));
            }
        }

        [Test]
        public void WhenRetrievingACustomer_ThatCustomerHasRightDetails()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();

                Customer sut = CustomerManager.ReadForSpecificCustomerById(db, "Manda");

                Assert.That(sut.ContactName, Is.EqualTo(sutCustomer.ContactName));
                Assert.That(sut.City, Is.EqualTo(sutCustomer.City));
                Assert.That(sut.PostalCode, Is.EqualTo(sutCustomer.PostalCode));

            }
        }

        [Test]
        public void WhenACustomerIsUpdated_TheTableDetailsUpdated()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();
                CustomerManager.UpdateCustomerById(db, "MANDA", city: "Newcastle");

                var customer = CustomerManager.ReadForSpecificCustomerById(db, "MANDA");

                Assert.That(customer.ContactName, Is.EqualTo(sutCustomer.ContactName));
                Assert.That(customer.City, Is.EqualTo("Newcastle"));
                Assert.That(customer.PostalCode, Is.EqualTo(sutCustomer.PostalCode));

            }
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                Assert.That(CustomerManager.UpdateCustomerById(db, "MANDA"), Is.EqualTo(false));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();

                CustomerManager.DeleteCustomerById(db, "MANDA");

                Assert.That(db.Customers.Count, Is.EqualTo(5));
            }
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();

                CustomerManager.DeleteCustomerById(db, "MANDA");

                var customer = CustomerManager.ReadForSpecificCustomerById(db, "MANDA");

                Assert.That(customer, Is.EqualTo(null));
            }
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Remove_ReturnsFalse()
        {
            Customer sutCustomer = new Customer()
            {
                CustomerId = "MANDA",
                ContactName = "Eliza",
                City = "London",
                PostalCode = "L1 5TA"
            };

            using (var db = new SouthwindContext())
            {
                db.Customers.Add(sutCustomer);
                db.SaveChanges();

                CustomerManager.DeleteCustomerById(db, "MANDA");

                Assert.That(CustomerManager.DeleteCustomerById(db, "MANDA"), Is.EqualTo(false));
            }
        }

        [TearDown]
        public void TearDown()
        {
            using (var db = new SouthwindContext())
            {
                var selectedCustomers =
                from c in db.Customers
                where c.CustomerId == "MANDA"
                select c;

                db.Customers.RemoveRange(selectedCustomers);
                db.SaveChanges();
            }
        }
    }
}