using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Data.Repositories;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        //protected readonly INorthwindRepository<Supplier> _supplierRepository;
        protected readonly INorthwindService<Supplier> _supplierService;
        protected readonly INorthwindRepository<Category> _categoryRepository;

        public SuppliersController(INorthwindRepository<Category> categoryRepository, INorthwindService<Supplier> supplierService)
        {
            //_supplierRepository = supplierRepository;
            _categoryRepository = categoryRepository;
            _supplierService = supplierService;
        }

        // GET: api/Suppliers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDTO>>> GetSuppliers()
        {
            var suppliers = _supplierService.GetAllAsync().Result;

            if (suppliers == null)
            {
                return NotFound();
            }

            return suppliers
                .Select(s => Utils.SupplierToDTO(s))
                .ToList();
        }

        [HttpGet("category")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
        {
            if (_categoryRepository.IsNull)
            {
                return NotFound();
            }

            return (await _categoryRepository.GetAllAsync())
                .Select(s => Utils.CategoryToDTO(s))
                .ToList();
        }

        // GET: api/Suppliers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierDTO>> GetSupplier(int id)
        {
            var supplier = await _supplierService.GetAsync(id);

            if(supplier == null)
            {
                return NoContent();
            }

            return Utils.SupplierToDTO(supplier);
        }

/*        //GET: api/suppliers/1/products
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
        }*/

        [HttpGet("category/{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
        {
            if (_categoryRepository.IsNull)
            {
                return NotFound();
            }

            var category = await _categoryRepository.FindAsync(id);

            if(category == null)
            {
                return NotFound();
            }
            
            return Utils.CategoryToDTO(category);
        }



        //GET: api/suppliers/1/products/1
        [HttpGet("{sId}/products/{pId}")]
        public async Task<ActionResult<ProductDTO>> GetProductFromSupplierId(int sId, int pId)
        {
            var supplier = await _supplierService.GetAsync(sId);

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
            _supplierService.UpdateAsync(id, supplier);

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, Utils.SupplierToDTO(supplier));
        }

        // POST: api/Suppliers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SupplierDTO>> PostSupplier(
            [Bind("CompanyName", "ContactName", "ContactTitle", "Country", "Products")]Supplier supplier)
        {
            if (!_supplierService.CreateAsync(supplier).Result)
            {
                return Problem("Entity set 'NorthwindContext.Suppliers'  is null.");
            }

            await _supplierService.SaveAsync();

            return CreatedAtAction("GetSupplier", new { id = supplier.SupplierId }, Utils.SupplierToDTO(supplier)); //This is Output from request
        }

        // DELETE: api/Suppliers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplier(int id)
        {
            var supplier = await _supplierService.GetAsync(id);

            if (supplier == null) return NotFound();

            supplier.Products.Select(p => p.SupplierId = null);

            var deletedSuccessfully = await _supplierService.DeleteAsync(id);

            if (!deletedSuccessfully) return NotFound();
            
            return NoContent();
        }

        private bool SupplierExists(int id)
        {
            return _supplierService.GetAsync(id).Result != null;
        }
    }
}
