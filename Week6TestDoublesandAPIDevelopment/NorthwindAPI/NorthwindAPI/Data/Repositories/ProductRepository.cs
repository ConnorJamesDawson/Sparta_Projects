using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Data.Repositories
{
    public class ProductRepository : NorthwindRepository<Product>
    {
        public ProductRepository(NorthwindContext context) : base(context)
        {
        }

        public override async Task<Product?> FindAsync(int id)
        {
            return await _dbSet
                .Where(s => s.ProductId == id)
                .Include(s => s.Supplier)
                .Include(s => s.Category)
                .FirstOrDefaultAsync();
        }
        public override async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _dbSet
                .Include(s => s.Supplier)
                .Include(s => s.Category)
                .ToListAsync();
        }

        public override void Remove(Product entity)
        {
            entity.Supplier = null;

            entity.Category = null;

            base.Remove(entity);
        }
    }
}
