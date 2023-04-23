using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.App.Data;
using RestaurantWebApp.App.Model;

namespace RestaurantWebApp.App.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(Category.Name == Category.DisplayOrder.ToString()) 
            {
                ModelState.AddModelError("Category.Name", "The DisplayOrder cannot exactly match the Name");
            }
            if(ModelState.IsValid)
            {
                await _db.Catagories.AddAsync(Category);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
