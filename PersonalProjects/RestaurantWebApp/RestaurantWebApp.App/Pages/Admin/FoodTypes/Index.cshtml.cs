using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.Admin.FoodTypes;

public class IndexModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public IEnumerable<FoodType> FoodTypes { get; set; }

    public IndexModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet()
    {
        FoodTypes = _unitOfWork.FoodType.GetAll();
    }
}
