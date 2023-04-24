using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.Admin.Categories;

public class IndexModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    public IEnumerable<Category> Categories { get; set; }

    public IndexModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public void OnGet()
    {
        Categories = _unitOfWork.Category.GetAll();
    }
}
