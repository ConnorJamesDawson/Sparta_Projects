using Microsoft.Extensions.Logging;
using Moq;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

namespace NorthwindAPI.Tests
{
    internal class ProductsServiceShould
    {
        [Category("Happy Path")]
        [Category("GetAllSuppliers")]
        [Test]
        public async Task GetAllAsync_WhenThereAreSuppliers_ReturnsListOfSuppliers()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            List<Product> suppliers = new List<Product> { It.IsAny<Product>() };
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.GetAllAsync().Result)
            .Returns(suppliers);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.GetAllAsync();
            Assert.That(result, Is.InstanceOf<IEnumerable<Product>>());
        }

        [Category("Sad Path")]
        [Category("GetAllSuppliers")]
        [Test]
        public async Task GetAllAsync_WhenThereAreNoSuppliers_ReturnsNull()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.GetAllAsync().Result)
            .Returns<Task>(null);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(true);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.GetAllAsync();
            Assert.That(result, Is.Null);
        }

        [Category("Happy Path")]
        [Category("GetSuppliers")]
        [Test]
        public async Task GetAsync_WhenGivenCorrectId_ReturnsASupplier()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(1).Result)
            .Returns(new Product());
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.GetAsync(1);
            Assert.That(result, Is.InstanceOf<Product>());
        }

        [Category("Sad Path")]
        [Category("GetSuppliers")]
        [Test]
        public async Task GetAsync_WhenGivenIncorrectId_ReturnsNull()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(1).Result)
            .Returns<Task>(null);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(true);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.GetAsync(1);
            Assert.That(result, Is.Null);
        }

        [Category("Happy Path")]
        [Category("CreateSuppliers")]
        [Test]
        public async Task CreateAsync_WhenGivenValidSupplier_ReturnsTrue()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.CreateAsync(new Product());
            Assert.That(result, Is.True);
        }

        [Category("Sad Path")]
        [Category("CreateSuppliers")]
        [Test]
        public async Task CreateAsync_WhenGivenAnInvalidSupplier_ReturnsFalse()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.CreateAsync(It.IsAny<Product>());
            Assert.That(result, Is.False);
        }

        [Category("Sad Path")]
        [Category("CreateSuppliers")]
        [Test]
        public async Task CreateAsync_WhenGivenAnNullRepository_ReturnsFalse()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(true);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.CreateAsync(new Product());
            Assert.That(result, Is.False);
        }

        [Category("Happy Path")]
        [Category("UpdateSuppliers")]
        [Test]
        public async Task Update_WhenGivenValidSupplier_ReturnsTrue()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(1).Result)
            .Returns(new Product());

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.UpdateAsync(1, new Product());
            Assert.That(result, Is.True);
        }

        [Category("Sad Path")]
        [Category("UpdateSuppliers")]
        [Test]
        public async Task Update_WhenGivenAnInvalidSupplier_ReturnsFalse()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(99).Result)
            .Returns<Task>(null);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.UpdateAsync(99, new Product());
            Assert.That(result, Is.False);
        }

        [Category("Happy Path")]
        [Category("RemoveSuppliers")]
        [Test]
        public async Task Remove_WhenGivenValidSupplier_ReturnsTrue()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(1).Result)
            .Returns(new Product());

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.DeleteAsync(1);
            Assert.That(result, Is.True);
        }

        [Category("Sad Path")]
        [Category("RemoveSuppliers")]
        [Test]
        public async Task Remove_WhenGivenAnInvalidSupplier_ReturnsFalse()
        {
            var mockRepository = GetRepository();
            var mockLogger = GetLogger();
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.IsNull)
            .Returns(false);
            Mock
            .Get(mockRepository)
            .Setup(sc => sc.FindAsync(99).Result)
            .Returns<Task>(null);

            var _sut = new NorthwindService<Product>(mockLogger, mockRepository);
            var result = await _sut.DeleteAsync(99);
            Assert.That(result, Is.False);
        }

        private static ILogger<INorthwindService<Product>> GetLogger()
        {
            return Mock.Of<ILogger<INorthwindService<Product>>>();
        }
        private static INorthwindRepository<Product> GetRepository()
        {
            return Mock.Of<INorthwindRepository<Product>>();
        }
    }
}
