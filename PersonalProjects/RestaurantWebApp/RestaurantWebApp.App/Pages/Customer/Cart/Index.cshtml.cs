using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System.Security.Claims;

namespace RestaurantWebApp.App.Pages.Customer.Cart
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public double TotalValueOfCart { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            TotalValueOfCart = 0;
        }

        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if(claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: sc => sc.ApplicationUserId == claim.Value,
                    includeProperties:"MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach(var item in ShoppingCartList)
                {
                    TotalValueOfCart += (item.MenuItem.Price * item.Count);
                }
            }
        }

        public IActionResult OnPostPlus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetByIdFirstOrDefault(sc => sc.Id == cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cart, 1);
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostMinus(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetByIdFirstOrDefault(sc => sc.Id == cartId);
            if(cart.Count == 1)
            {
                _unitOfWork.ShoppingCart.Delete(cart);
                _unitOfWork.SaveChanges();
            }
            else
            {
                _unitOfWork.ShoppingCart.DecrementCount(cart, 1);
            }
            return RedirectToPage("/Customer/Cart/Index");
        }
        public IActionResult OnPostRemove(int cartId)
        {
            var cart = _unitOfWork.ShoppingCart.GetByIdFirstOrDefault(sc => sc.Id == cartId);
            _unitOfWork.ShoppingCart.Delete(cart);
            _unitOfWork.SaveChanges();
            return RedirectToPage("/Customer/Cart/Index");
        }
    }
}
