using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.Admin.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Category = _unitOfWork.Category.GetByIdFirstOrDefault(f => f.Id == id)!;
        }

        public async Task<IActionResult> OnPost()
        {
            var categoryFromDb = _unitOfWork.Category.GetByIdFirstOrDefault(f => f.Id == Category.Id)!;
            if (categoryFromDb != null)
            {
                _unitOfWork.Category.Delete(categoryFromDb!);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Category deleted successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
