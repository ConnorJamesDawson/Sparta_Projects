using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.App.Data;
using RestaurantWebApp.App.Model;

namespace RestaurantWebApp.App.Pages.Catagories;

public class IndexModel : PageModel
{
    private readonly ApplicationDbContext _db;
    public IEnumerable<Category> Categories { get; set; }

    public IndexModel(ApplicationDbContext db)
    {
        _db = db;
    }

    public void OnGet()
    {
        Categories = _db.Catagories;
    }
}
