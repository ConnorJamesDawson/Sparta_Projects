using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using RestaurantWebApp.Utility;
using System.Security.Claims;

namespace RestaurantWebApp.App.Pages.Customer.Cart
{
    [Authorize]
    [BindProperties]
    public class SummaryModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }

        public SummaryModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            OrderHeader = new OrderHeader();
        }

        public void OnGet()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity!;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claim != null)
            {
                ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: sc => sc.ApplicationUserId == claim.Value,
                    includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");
                foreach (var item in ShoppingCartList)
                {
                    OrderHeader.OrderTotal += (item.MenuItem.Price * item.Count);
                }
                ApplicationUser currentUser = _unitOfWork.ApplicationUser.GetByIdFirstOrDefault(au=> au.Id == claim.Value);
                OrderHeader.PickupName = currentUser.FirstName + " " + currentUser.LastName;
                OrderHeader.PhoneNumber = currentUser.PhoneNumber;
            }
        }
		public void OnPost()
		{
			var claimsIdentity = (ClaimsIdentity)User.Identity!;
			var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
			if (claim != null)
			{
				ShoppingCartList = _unitOfWork.ShoppingCart.GetAll(filter: sc => sc.ApplicationUserId == claim.Value,
					includeProperties: "MenuItem,MenuItem.FoodType,MenuItem.Category");
				foreach (var item in ShoppingCartList)
				{
					OrderHeader.OrderTotal += (item.MenuItem.Price * item.Count);
				}
                OrderHeader.Status = SD.StatusPending;
                OrderHeader.OrderDate = System.DateTime.Now;
                OrderHeader.UserId = claim.Value;
                OrderHeader.PickUpTime = Convert.ToDateTime($"{OrderHeader.PickUpDate.ToShortDateString()} {OrderHeader.PickUpTime.ToShortTimeString()}");
			    _unitOfWork.OrderHeader.Add(OrderHeader);
                _unitOfWork.SaveChanges();

                foreach(var item in ShoppingCartList)
                {
                    OrderDetails orderDetails = new()
                    {
                        MenuItemId = item.MenuItemId,
                        OrderId = OrderHeader.Id,
                        Name = item.MenuItem.Name,
                        Price = item.MenuItem.Price,
                        Count = item.Count
                    };
                    _unitOfWork.OrderDetail.Add(orderDetails);
                }

                _unitOfWork.ShoppingCart.DeleteRange(ShoppingCartList);
                _unitOfWork.SaveChanges();
            }
		}
	}
}
