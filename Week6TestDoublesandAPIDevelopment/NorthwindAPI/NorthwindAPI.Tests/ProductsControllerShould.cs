using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindAPI.Controllers;
using NorthwindAPI.Models;
using NorthwindAPI.Services;
using System.Collections.Generic;
using System.Net;

namespace NorthwindAPI.Tests;

internal class ProductsControllerShould
{

    [Category("Happy Path")]
    [Category("GetAllProducts")]
    [Test]
    public async Task GetProducts_WhenThereAreProductss_ReturnsListOfProductDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        List<Product> products = new List<Product>();
        Mock.Get(mockService)
        .Setup(sc => sc.GetAllAsync().Result)
        .Returns(products);


        var sut = new ProductsController(mockService);
        var result = await sut.GetProducts();
        Assert.That(result.Value, Is.InstanceOf<IEnumerable<ProductDTO>>());
    }

    [Category("Sad Path")]
    [Category("GetAllProducts")]
    [Test]
    public async Task GetProducts_WhenThereAreNoProducts_ReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        List<Product> products = new List<Product>();
        Mock.Get(mockService)
        .Setup(sc => sc.GetAllAsync().Result)
        .Returns<IEnumerable<Task>>(null);



        var sut = new ProductsController(mockService);
        var result = await sut.GetProducts();
        Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("GetProduct")]
    [Test]
    public async Task GetProduct_WhenThereAreSuppliers_ReturnsASupplierDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Product());


        var sut = new ProductsController(mockService);
        var result = await sut.GetProduct(1);
        Assert.That(result.Value, Is.InstanceOf<ProductDTO>());
    }

    [Category("Sad Path")]
    [Category("GetProduct")]
    [Test]
    public async Task GetProduct_WhenGivenBadId_ReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        Mock.Get(mockService)
            .Setup(sc => sc.GetAsync(99).Result)
            .Returns<Task>(null);


        var sut = new ProductsController(mockService);
        var result = await sut.GetProduct(99);
        Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenValidSupplierId_ReturnsAnUpdatedSupplierDTO()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Product>()).Result)
        .Returns(true);


        var sut = new ProductsController(mockService);
        var result = await sut.PutProduct(1, new Product());

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
    }

    [Category("Sad Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenABadId_ReturnsAnBAdRequest()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Product>()).Result)
        .Returns(false);


        var sut = new ProductsController(mockService);
        var result = await sut.PutProduct(99, new Product());

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }
    [Category("Sad Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenABadUpdateSupplier_ReturnsAnBAdRequest()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Product>()).Result)
        .Returns(false);


        var sut = new ProductsController(mockService);
        var result = await sut.PutProduct(1, null);

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("PostSuppliers")]
    [Test]
    public async Task PostSupplier_WhenGivenAValidSupplier_ReturnsCreatedAtActionResult()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();

        Mock.Get(mockService)
        .Setup(sc => sc.CreateAsync(It.IsAny<Product>()).Result)
        .Returns(true);

        var sut = new ProductsController(mockService);

        var product = new Product()
        {
            ProductName = "Windows CD",
            UnitPrice = 10.0m
        };

        var result = sut.PostProduct(product).Result;

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
    }

    [Category("Sad Path")]
    [Category("PostSuppliers")]
    [Test]
    public async Task PostSupplier_WhenGivenANullSupplier_ReturnsCreatedAtActionResult()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();

        Mock.Get(mockService)
        .Setup(sc => sc.CreateAsync(It.IsAny<Product>()).Result)
        .Returns(false);

        var sut = new ProductsController(mockService);

        var result = sut.PostProduct(null).Result;

        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("Remove Suppliers")]
    [Test]
    public async Task RemoveSupplier_WhenGivenAValidSupplier_RemovesSupplierAndReturnsNoContent()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.DeleteAsync(1).Result)
        .Returns(true);
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Product());


        var sut = new ProductsController(mockService);
        var result = await sut.DeleteProduct(1);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NoContentResult>(result);
    }
    [Category("Sad Path")]
    [Category("Remove Suppliers")]
    [Test]
    public async Task RemoveSupplier_WhenGivenANonValidSupplier_RemovesSupplierAndReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Product>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.DeleteAsync(1).Result)
        .Returns(false);
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Product());


        var sut = new ProductsController(mockService);
        var result = await sut.DeleteProduct(1);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
}
