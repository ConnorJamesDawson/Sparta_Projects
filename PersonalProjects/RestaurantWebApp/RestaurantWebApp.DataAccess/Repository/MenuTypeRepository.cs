using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository;

public class MenuItemRepository : Repository<MenuItem> , IMenuItemRepository
{ 
    private readonly ApplicationDbContext _context;

    public MenuItemRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(MenuItem menuItem)
    {
        var objFromDb = _context.MenuItem.FirstOrDefault(c => c.Id == menuItem.Id);
        objFromDb!.Name = menuItem.Name;
        objFromDb!.Description = menuItem.Description;
        objFromDb!.Price = menuItem.Price;
        objFromDb!.FoodTypeId = menuItem.FoodTypeId;
        objFromDb!.CategoryId = menuItem.CategoryId;
        if(objFromDb.ImageURL!= null)
        {
            objFromDb.ImageURL = menuItem.ImageURL;
        }
    }
}
