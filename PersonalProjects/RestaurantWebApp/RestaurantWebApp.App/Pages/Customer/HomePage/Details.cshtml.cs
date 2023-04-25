using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System.Security.Claims;

namespace RestaurantWebApp.App.Pages.Customer.HomePage
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public ShoppingCart ShoppingCart { get; set; }

        public void OnGet(int id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCart = new()
            {
                ApplicationUserId = claim.Value,
                MenuItem = _unitOfWork.MenuItem.GetByIdFirstOrDefault(mi => mi.Id == id, includeProperties: "Category,FoodType"),
                MenuItemId = id
            };
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                ShoppingCart fromDb = _unitOfWork.ShoppingCart.GetByIdFirstOrDefault(
                    filter: sc => sc.ApplicationUserId == ShoppingCart.ApplicationUserId &&
                    sc.MenuItemId == ShoppingCart.MenuItemId
                    );
                if (fromDb == null) //If null create entry
                {
                    _unitOfWork.ShoppingCart.Add(ShoppingCart);
                    _unitOfWork.SaveChanges();
                }
                else
                {

                    _unitOfWork.ShoppingCart.IncrementCount(fromDb, ShoppingCart.Count);

                }
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
