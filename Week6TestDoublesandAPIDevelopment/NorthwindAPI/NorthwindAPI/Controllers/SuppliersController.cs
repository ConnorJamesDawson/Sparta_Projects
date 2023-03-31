using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using System.Net;
using System.Security.Cryptography;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly NorthwindContext _context;
        private readonly ILogger _logger;
        private readonly INorthwindRepository<Supplier> _supplierRepository;

        public SuppliersController(NorthwindContext context, ILogger<SuppliersController> logger, INorthwindRepository<Supplier> supplierRepository)
        {
            _context = context;
            _logger = logger;
            _supplierRepository = supplierRepository;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliers()
        {
            if (_context.Suppliers == null)
            {
                return NotFound();
            }
            return (await _supplierRepository.GetAllAsync())
                .Select(s => Utils.SupplierToDTO(s))
                .ToList();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            if (_supplierRepository.IsNull)
            {
                return NotFound();
            }

            var supplier = await _supplierRepository.FindAsync(id);


            if (supplier == null)
            {
                _logger.LogWarning($"Supplier with id:{id} was not found");
                return NotFound();
            }

            _logger.LogInformation($"Supplier with id:{id} was found");

            return Utils.SupplierToDTO(supplier);
        }

        //GET: api/suppliers/1/products
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsBySupplierId(int id)
        {
            if (_supplierRepository.IsNull)
            {
                return NotFound();
            }

            var supplier = await _supplierRepository.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            return supplier.Products
                    .Select(p => Utils.ProductToDTO(p))
                    .ToList();
        }

        //GET: api/suppliers/1/products/1
        [HttpGet("{sId}/products/{pId}")]
        public async Task<ActionResult<ProductDTO>> GetProductFromSupplierId(int sId, int pId)
        {
            if (_supplierRepository.IsNull)
            {
                return NotFound();
            }

            var supplier = await _supplierRepository.FindAsync(sId);

            if (supplier == null)
            {
                return NotFound();
            }

            return Utils.ProductToDTO(supplier.Products
                .Where(p => p.ProductId == pId)
                .FirstOrDefault()!);
        }

        // PUT: api/Suppliers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult> PutSupplier(int id,
            [Bind("SupplierId", "CompanyName", "CoontactTitle", "Country")] Supplier supplier)
        {
            if (id != supplier.SupplierId)
            {
                return BadRequest();
            }

            _supplierRepository.Update(supplier);

            try
            {
                await _supplierRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, Utils.SupplierToDTO(supplier));
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplier(
            [Bind("CompanyName", "ContactName", "ContactTitle", "Country", "Products")]Supplier supplier)
        {
            if (_supplierRepository.IsNull)
            {
                return Problem("Entity set 'NorthwindContext.Suppliers'  is null.");
            }

            _supplierRepository.Add(supplier);

            await _supplierRepository.SaveAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, Utils.SupplierToDTO(supplier)); //This is Output from request
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            if (_supplierRepository.IsNull)
            {
                return NotFound();
            }

            var supplier = await _supplierRepository.FindAsync(id);

            if (supplier == null)
            {
                return NotFound();
            }

            supplier.Products.Select(p => p.SupplierId = null);

            _supplierRepository.Remove(supplier);

            await _supplierRepository.SaveAsync();

            _logger.LogInformation($"Supplier with id:{id} was found and removed");

            return NoContent();
        }

        private bool SupplierExists(int id)
        {
            var supplier = _supplierRepository.FindAsync(id);

            if (supplier != null) return true;
            else return false;
        }
    }
}
