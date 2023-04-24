using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantWebApp.DataAccess.Repository;

public class FoodTypeRepository : Repository<FoodType> , IFoodTypeRepository
{

    private readonly ApplicationDbContext _context;

    public FoodTypeRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public void Update(FoodType foodType)
    {
        var objFromDb = _context.FoodType.FirstOrDefault(c => c.Id == foodType.Id);
        objFromDb!.Name = foodType.Name;
    }
}
