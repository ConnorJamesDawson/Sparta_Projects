using Microsoft.EntityFrameworkCore;
using NorthwindAPI.Models;

namespace NorthwindAPI.Data.Repositories;

public class CategoryRepository : NorthwindRepository<Category>
{
    public CategoryRepository(NorthwindContext context) : base(context)
    {
    }
    public override async Task<Category?> FindAsync(int id)
    {
        return await _dbSet
            .Where(s => s.CategoryId == id)
            .Include(s => s.Products)
            .FirstOrDefaultAsync();
    }
    public override async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _dbSet
            .Include(s => s.Products)
            .ToListAsync();
    }
}
