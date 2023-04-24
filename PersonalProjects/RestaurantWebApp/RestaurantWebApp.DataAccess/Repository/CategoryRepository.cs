using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void Update(Category category)
        {
            var objFromDb = _context.Catagory.FirstOrDefault(c=> c.Id == category.Id);
            objFromDb.Name = category.Name;
            objFromDb.DisplayOrder = category.DisplayOrder;
        }
    }
}
