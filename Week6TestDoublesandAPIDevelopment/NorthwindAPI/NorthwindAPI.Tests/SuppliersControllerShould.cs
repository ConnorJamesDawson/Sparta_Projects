using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindAPI.Controllers;
using NorthwindAPI.Models;
using NorthwindAPI.Services;
using System.Net;

namespace NorthwindAPI.Tests;

internal class SuppliersControllerShould
{

    [Category("Happy Path")]
    [Category("GetSuppliers")]
    [Test]
    public async Task GetSuppliers_WhenThereAreSuppliers_ReturnsListOfSupplierDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.GetAllAsync().Result)
        .Returns(suppliers);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.GetSuppliers();
        Assert.That(result.Value, Is.InstanceOf<IEnumerable<SupplierDTO>>());
    }

    [Category("Happy Path")]
    [Category("GetSuppliers")]
    [Test]
    public async Task GetSupplier_WhenThereAreSuppliers_ReturnsASupplierDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Supplier());


        var sut = new SuppliersController(null, mockService);
        var result = await sut.GetSupplier(1);
        Assert.That(result.Value, Is.InstanceOf<SupplierDTO>());
    }

    [Category("Happy Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenThereAreSuppliers_ReturnsAnUpdatedSupplierDTO()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Supplier>()).Result)
        .Returns(true);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.PutSupplier(1, new Supplier());

        Assert.That(result, Is.Not.Null);
    }

    [Category("Happy Path")]
    [Category("PostSuppliers")]
    [Test]
    public async Task PostSupplier_WhenThereAreSuppliers_ReturnsListOfSupplierDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };

        Mock.Get(mockService)
        .Setup(sc => sc.CreateAsync(It.IsAny<Supplier>()).Result)
        .Returns(true);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.PostSupplier(new Supplier());

        Assert.That(result, Is.Not.Null);
    }

    [Category("Happy Path")]
    [Category("Remove Suppliers")]
    [Test]
    public async Task RemoveSupplier_WhenThereAreSuppliers_ReturnsListOfSupplierDTOs()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.DeleteAsync(1).Result)
        .Returns(true);
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Supplier());


        var sut = new SuppliersController(null, mockService);
        var result = await sut.DeleteSupplier(1);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NoContentResult>(result);
    }

}
