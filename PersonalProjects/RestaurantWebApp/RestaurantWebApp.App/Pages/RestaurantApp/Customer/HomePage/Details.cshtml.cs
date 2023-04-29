using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using RestaurantWebApp.Utility;
using System.Security.Claims;

namespace RestaurantWebApp.App.Pages.RestaurantApp.Customer.HomePage
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
                    HttpContext.Session.SetInt32(SD.SessionCart, _unitOfWork.ShoppingCart.GetAll(
                        sc=> sc.ApplicationUserId == ShoppingCart.ApplicationUserId).ToList().Count);
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
