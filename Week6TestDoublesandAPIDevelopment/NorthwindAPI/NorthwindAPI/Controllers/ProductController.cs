using Microsoft.AspNetCore.Mvc;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;

namespace NorthwindAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger _logger;
    private readonly INorthwindRepository<Supplier> _supplierRepository;

    public ProductController(ILogger<SuppliersController> logger, INorthwindRepository<Supplier> supplierRepository)
    {
        _logger = logger;
        _supplierRepository = supplierRepository;
    }

}
