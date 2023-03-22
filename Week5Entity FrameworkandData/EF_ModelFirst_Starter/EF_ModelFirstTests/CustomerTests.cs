using EF_ModelFirst;

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
                var query = db.Customers
                    .Where(c => c.CustomerId == sutCustomer.CustomerId);
                db.Customers.Add(sutCustomer);
                db.SaveChanges();
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
            Assert.Fail();
        }

        [Test]
        public void WhenRetrievingACustomer_ThatCustomerHasRightDetails()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsUpdated_TheTableDetailsUpdated()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Update_ReturnsFalse()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsRemoved_TheNumberOfCustomersDecreasesBy1()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsRemoved_TheyAreNoLongerInTheDatabase()
        {
            Assert.Fail();
        }

        [Test]
        public void WhenACustomerIsNotInTheDatabase_Remove_ReturnsFalse()
        {
            Assert.Fail();
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