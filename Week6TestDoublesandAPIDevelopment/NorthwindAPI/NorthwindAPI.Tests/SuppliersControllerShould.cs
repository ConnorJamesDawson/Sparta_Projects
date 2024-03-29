﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NorthwindAPI.Controllers;
using NorthwindAPI.Models;
using NorthwindAPI.Services;
using System.Collections.Generic;
using System.Net;

namespace NorthwindAPI.Tests;

internal class SuppliersControllerShould
{

    [Category("Happy Path")]
    [Category("GetAllSuppliers")]
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

    [Category("Sad Path")]
    [Category("GetAllSuppliers")]
    [Test]
    public async Task GetSuppliers_WhenThereAreNotSuppliers_ReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.GetAllAsync().Result)
        .Returns<IEnumerable<Task>>(null);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.GetSuppliers();
        Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
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

    [Category("Sad Path")]
    [Category("GetSuppliers")]
    [Test]
    public async Task GetSupplier_WhenGivenBadId_ReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
            .Setup(sc => sc.GetAsync(99).Result)
            .Returns<Task>(null);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.GetSupplier(99);
        Assert.IsInstanceOf<NotFoundObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenValidSupplierId_ReturnsAnUpdatedSupplierDTO()
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
        Assert.IsInstanceOf<CreatedAtActionResult>(result.Result);
    }

    [Category("Sad Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenABadId_ReturnsAnBAdRequest()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Supplier>()).Result)
        .Returns(false);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.PutSupplier(99, new Supplier());

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }
    [Category("Sad Path")]
    [Category("UpdateSuppliers")]
    [Test]
    public async Task UpdateSupplier_WhenGivenABadUpdateSupplier_ReturnsAnBAdRequest()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        Supplier Microsoft = new();

        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.UpdateAsync(1, It.IsAny<Supplier>()).Result)
        .Returns(false);


        var sut = new SuppliersController(null, mockService);
        var result = await sut.PutSupplier(1, null);

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("PostSuppliers")]
    [Test]
    public async Task PostSupplier_WhenGivenAValidSupplier_ReturnsCreatedAtActionResult()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        Mock.Get(mockService)
        .Setup(sc => sc.CreateAsync(It.IsAny<Supplier>()).Result)
        .Returns(true);

        var sut = new SuppliersController(null, mockService);

        var supplier = new Supplier()
        {
            CompanyName = "Microsoft",
            City = "California"
        };

        var result = sut.PostSupplier(supplier).Result;

        Assert.That(result, Is.Not.Null);
        Assert.IsInstanceOf<CreatedAtActionResult> (result.Result);
    }

    [Category("Sad Path")]
    [Category("PostSuppliers")]
    [Test]
    public async Task PostSupplier_WhenGivenANullSupplier_ReturnsCreatedAtActionResult()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();

        Mock.Get(mockService)
        .Setup(sc => sc.CreateAsync(It.IsAny<Supplier>()).Result)
        .Returns(false);

        var sut = new SuppliersController(null, mockService);

        var result = sut.PostSupplier(null).Result;

        Assert.IsInstanceOf<BadRequestObjectResult>(result.Result);
    }

    [Category("Happy Path")]
    [Category("Remove Suppliers")]
    [Test]
    public async Task RemoveSupplier_WhenGivenAValidSupplier_RemovesSupplierAndReturnsNoContent()
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
    [Category("Sad Path")]
    [Category("Remove Suppliers")]
    [Test]
    public async Task RemoveSupplier_WhenGivenANonValidSupplier_RemovesSupplierAndReturnsNotFound()
    {
        var mockService = Mock.Of<INorthwindService<Supplier>>();
        List<Supplier> suppliers = new List<Supplier> { Mock.Of<Supplier>(s => s.Products == Mock.Of<List<Product>>()) };
        Mock.Get(mockService)
        .Setup(sc => sc.DeleteAsync(1).Result)
        .Returns(false);
        Mock.Get(mockService)
        .Setup(sc => sc.GetAsync(1).Result)
        .Returns(new Supplier());


        var sut = new SuppliersController(null, mockService);
        var result = await sut.DeleteSupplier(1);

        Assert.IsNotNull(result);
        Assert.IsInstanceOf<NotFoundResult>(result);
    }
}
