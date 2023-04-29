using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.RestaurantApp.Admin.FoodTypes
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            FoodType = _unitOfWork.FoodType.GetByIdFirstOrDefault(ft => ft.Id == id);
        }

        public async Task<IActionResult> OnPost()
        {
            var foodTypeFromDb = _unitOfWork.FoodType.GetByIdFirstOrDefault(ft => ft.Id == FoodType.Id);

            if (foodTypeFromDb != null)
            {
                _unitOfWork.FoodType.Delete(foodTypeFromDb!);
                _unitOfWork.SaveChanges();
                TempData["success"] = "FoodType deleted successfully";
                return RedirectToPage("Index");
            }
            TempData["error"] = "Error: Could not find FoodType in the database";
            return Page();
        }
    }
}
