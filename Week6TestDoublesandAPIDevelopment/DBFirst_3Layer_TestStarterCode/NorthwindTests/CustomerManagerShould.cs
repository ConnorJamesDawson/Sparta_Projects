using Moq;
using NorthwindBusiness;
using NorthwindData;
using NorthwindData.Services;
using NUnit.Framework;

namespace NorthwindTests
{
    internal class CustomerManagerShould
    {
        private CustomerManager _sut;


        [Test]
        public void BeAbleToBeConstructedUsingMoq()
        {
            var mockCustomerService = new Mock<ICustomerService>();

            _sut = new CustomerManager(mockCustomerService.Object);

            Assert.That(_sut, Is.InstanceOf<CustomerManager>());
        }

        [Test]
        public void WhenCalledWithValidId_Update_ReturnsTrue()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer
            {
                CustomerId = "ROCK"
            };
            mockCustomerService.Setup(
                cs => cs.GetCustomerById("ROCK"))
                    .Returns(originalCustomer);

            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            var result = _sut.Update(
                "ROCK", It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void WhenCalledWithValidIdAndValues_Update_CorrectlyChangesValues()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            var originalCustomer = new Customer()
            {
                CustomerId = "ROCK",
                ContactName = "Rocky Raccoon",
                CompanyName = "Zoo UK",
                City = "Telford"

            };
            mockCustomerService.Setup(
                cs => cs.GetCustomerById("ROCK"))
                    .Returns(originalCustomer);
            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            _sut.Update("ROCK", "Rocky Raccoon", "UK", "Chester", null);

            // Assert
            Assert.That(
                _sut.SelectedCustomer.ContactName,
                Is.EqualTo("Rocky Raccoon"));
            Assert.That(
                _sut.SelectedCustomer.CompanyName,
                Is.EqualTo("Zoo UK"));
            Assert.That(
                _sut.SelectedCustomer.Country,
                Is.EqualTo("UK"));
            Assert.That(
                _sut.SelectedCustomer.City,
                Is.EqualTo("Chester"));
        }

        [Test]
        public void WhenCalledWithInvalidId_Update_ReturnsFalse()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            mockCustomerService.Setup(
                cs => cs.GetCustomerById("ROCK"))
                    .Returns((Customer)null);
            _sut = new CustomerManager(mockCustomerService.Object);
            // Act
            var result = _sut.Update(
                "ROCK", It.IsAny<string>(), It.IsAny<string>(),
                It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void WhenCalledWithInvalidId_Update_DoesNotChangeTheSelectedCustomer()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            mockCustomerService.Setup(
                cs => cs.GetCustomerById("ROCK"))
                    .Returns((Customer)null);

            var originalCustomer = new Customer()
            {
                CustomerId = "ROCK",
                ContactName = "Rocky Raccoon",
                CompanyName = "Zoo UK",
                City = "Telford"
            };

            _sut = new CustomerManager(mockCustomerService.Object);
            _sut.SelectedCustomer = originalCustomer;

            // Act
            _sut.Update("ROCK", "Rocky Raccoon", "UK", "Chester", null);

            // Assert that SelectedCustomer is unchanged
            Assert.That(
                _sut.SelectedCustomer.ContactName,
                Is.EqualTo("Rocky Raccoon"));
            Assert.That(
                _sut.SelectedCustomer.CompanyName,
                Is.EqualTo("Zoo UK"));
            Assert.That(
                _sut.SelectedCustomer.Country,
                Is.EqualTo(null));
            Assert.That(
                _sut.SelectedCustomer.City,
                Is.EqualTo("Telford"));
        }
        [Test]
        public void WhenUpdateIsCalledWithValidId_SaveCustomerChanges_IsCalledOnce()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();
            mockCustomerService.Setup(cs => cs.GetCustomerById("ROCK"))
            .Returns(new Customer());

            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            var result = _sut.Update("ROCK", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            mockCustomerService.Verify(cs => cs.SaveCustomerChanges(), Times.Once);
        }

        [Test]
        public void LetsSeeWhatHappens_WhenUpdateIsCalled_IfAllInvocationsArentSetUp()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>()))
            .Returns(new Customer());

            mockCustomerService.Setup(cs => cs.SaveCustomerChanges());

            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            var result = _sut.Update("ROCK", It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());

            // Assert
            Assert.That(result);
        }

        [Test]
        public void WhenCreateIsCalled_ServiceCreateIsCalled()
        {
            // Arrange
            var mockCustomerService = new Mock<ICustomerService>();

            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            _sut.Create("ROCK", null, null, null);

            // Assert
            mockCustomerService.Verify(cs => cs.CreateCustomer(It.IsAny<Customer>()), Times.Once);
        }
        [Test]
        public void WhenDeleteIsCalled_ServiceDeleteIsCalled()
        {
            var mockCustomerService = new Mock<ICustomerService>(MockBehavior.Strict);
            mockCustomerService.Setup(cs => cs.GetCustomerById(It.IsAny<string>())).Returns(new Customer());
            mockCustomerService.Setup(cs => cs.RemoveCustomer(It.IsAny<Customer>()));

            _sut = new CustomerManager(mockCustomerService.Object);

            // Act
            _sut.Delete(It.IsAny<string>());

            // Assert
            mockCustomerService.VerifyAll();
        }
    }
}
