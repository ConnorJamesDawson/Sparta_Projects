using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;

namespace NorthwindAPI.Tests;

public class RepositoryTests
{

    private NorthwindContext _context;
    private SuppliersRepository _sut;

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        var options = new DbContextOptionsBuilder<NorthwindContext>()
        .UseInMemoryDatabase("NorthwindDB").Options;
        _context = new NorthwindContext(options);

        _sut = new SuppliersRepository(_context);
    }

    [SetUp]
    public void SetUp()
    {

        if (_context.Suppliers != null) // <- if anything is in Suppliers, Delete it
        {
            _context.Suppliers.RemoveRange(_context.Suppliers);
        }

        _context.Suppliers!.AddRange( // <- Seed function
        new List<Supplier>
        {
             new Supplier
             {
                 SupplierId = 1,
                 CompanyName = "Sparta Global",
                 City = "Birmingham",
                 Country = "UK",
                 ContactName = "Nish Mandal",
                 ContactTitle = "Manager"
             },
             new Supplier {
                 SupplierId = 2,
                 CompanyName = "Nintendo",
                 City = "Tokyo",
                 Country = "Japan",
                 ContactName = "Shigeru Miyamoto",
                 ContactTitle = "CEO"
             }
        });
        _context.SaveChanges();
    }

    [Category("Happy Path")]
    [Category("FindAsync")]
    [Test]
    public void FindAsync_GivenValidID_ReturnsCorrectSupplier()
    {
        var result = _sut.FindAsync(1).Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<Supplier>());
        Assert.That(result.CompanyName, Is.EqualTo("Sparta Global"));
    }
    [Category("Sad Path")]
    [Category("FindAsync")]
    [Test]
    public void FindAsync_GivenInvalidID_ReturnsCorrectSupplier()
    {
        var result = _sut.FindAsync(3).Result;
        Assert.That(result, Is.Null);
    }

    [Category("Happy Path")]
    [Category("FindAllAsync")]
    [Test]
    public void FindAllAsync_GivenValidDatabase_ReturnsCorrectList()
    {
        var result = _sut.GetAllAsync().Result;
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
    }

    [Category("Happy Path")]
    [Category("Add")]
    [Test]
    public async Task AddSupplier_GivenValidSupplier_ReturnsCorrectSupplierAsync()
    {
        _sut.Add(new Supplier
        {
            SupplierId = 3,
            CompanyName = "Microsoft",
            City = "California",
            Country = "USA",
            ContactName = "Bill Bates",
            ContactTitle = "CEO"
        });

        await _sut.SaveAsync();

        var result = _sut.FindAsync(3).Result;

        Assert.That(result, Is.Not.Null);
        Assert.That(result, Is.TypeOf<Supplier>());
        Assert.That(result.CompanyName, Is.EqualTo("Microsoft"));
    }

    [Category("Add")]
    [Test]
    public async Task AddSupplier_GivenValidSupplier_AltersListCorrectlyAsync()
    {
        _sut.Add(new Supplier
        {
            SupplierId = 3,
            CompanyName = "Microsoft",
            City = "California",
            Country = "USA",
            ContactName = "Bill Bates",
            ContactTitle = "CEO"
        });
        await _sut.SaveAsync();
        var result = _sut.GetAllAsync().Result;

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(3));
    }

    [Category("Remove")]
    [Test]
    public async Task RemoveSupplier_GivenValidId_RemovesFromDatabaseAsync()
    {
        _sut.Add(new Supplier
        {
            SupplierId = 3,
            CompanyName = "Microsoft",
            City = "California",
            Country = "USA",
            ContactName = "Bill Bates",
            ContactTitle = "CEO"
        });

        await _sut.SaveAsync();
        _sut.Remove(_sut.FindAsync(3).Result);
        await _sut.SaveAsync();

        Assert.That(_sut.FindAsync(3).Result, Is.Null);
        Assert.That(_sut.GetAllAsync().Result.Count, Is.EqualTo(2));
    }
    [Category("Update")]
    [Test]
    public async Task UpdateSupplier_GivenValidId_UpdatesSupplierAsync()
    {
        var newSupplier = new Supplier
        {
            SupplierId = 4,
            CompanyName = "Microsoft",
            City = "California",
            Country = "USA",
            ContactName = "Bill Bates",
            ContactTitle = "CEO"
        };
        _sut.Add(newSupplier);

        await _sut.SaveAsync();

        newSupplier.Country = "Canada";
        newSupplier.City = "California";

        _sut.Update(newSupplier);

        await _sut.SaveAsync();

        Assert.That(_sut.FindAsync(4).Result.Country, Is.EqualTo("Canada"));
        Assert.That(_sut.FindAsync(4).Result.City, Is.EqualTo("California"));
    }
}
