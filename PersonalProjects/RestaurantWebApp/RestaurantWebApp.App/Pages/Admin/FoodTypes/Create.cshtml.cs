using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.Admin.FoodTypes
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public FoodType FoodType { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.FoodType.Add(FoodType);
                _unitOfWork.SaveChanges();
                TempData["success"] = "FoodType created successfully";
                return RedirectToPage("Index");
            }
            TempData["error"] = "Error: You have not filled out the for correctly";
            return Page();
        }
    }
}
