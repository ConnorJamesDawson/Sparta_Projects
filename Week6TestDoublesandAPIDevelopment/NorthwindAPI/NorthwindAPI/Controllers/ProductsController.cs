using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;
using NorthwindAPI.Services;

namespace NorthwindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        protected readonly INorthwindService<Product> _productService;

        public ProductsController(INorthwindService<Product> supplierService)
        {
            _productService = supplierService;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            var products = _productService.GetAllAsync().Result;
            if (products == null)
            {
                return NotFound();
            }
            return products
                .Select(p => Utils.ProductToDTO(p))
                .ToList();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {

            var product = await _productService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Utils.ProductToDTO(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, 
            [Bind("ProductId", "SupplierId", "CategoryId", "ProductName", "UnitPrice")] Product product)
        {
            _productService.UpdateAsync(id, product);

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, Utils.ProductToDTO(product));
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (!_productService.CreateAsync(product).Result)
            {
                return Problem("Entity set 'NorthwindContext.Products'  is null.");
            }

            await _productService.SaveAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productService.GetAsync(id);

            if (product == null) return NotFound();

            product.SupplierId = null;
            product.CategoryId = null;

            var deletedSuccessfully = await _productService.DeleteAsync(id);

            if (!deletedSuccessfully) return NotFound();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _productService.GetAsync(id).Result != null;
        }
    }
}
