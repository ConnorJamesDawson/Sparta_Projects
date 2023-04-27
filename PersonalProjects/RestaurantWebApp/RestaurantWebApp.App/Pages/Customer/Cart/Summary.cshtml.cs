using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using RestaurantWebApp.Utility;
using Stripe.Checkout;
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
                ApplicationUser currentUser = _unitOfWork.ApplicationUser.GetByIdFirstOrDefault(au => au.Id == claim.Value);
                OrderHeader.PickupName = currentUser.FirstName + " " + currentUser.LastName;
                OrderHeader.PhoneNumber = currentUser.PhoneNumber;
            }
        }
        public IActionResult OnPost()
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
                OrderHeader.OrderDate = DateTime.Now;
                OrderHeader.UserId = claim.Value;
                OrderHeader.PickUpTime = Convert.ToDateTime($"{OrderHeader.PickUpDate.ToShortDateString()} {OrderHeader.PickUpTime.ToShortTimeString()}");
                _unitOfWork.OrderHeader.Add(OrderHeader);
                _unitOfWork.SaveChanges();

                foreach (var item in ShoppingCartList)
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

                var domain = "https://localhost:7176/Customer/Cart/OrderConfirmation?id=" + OrderHeader.Id;
                var options = new SessionCreateOptions
                {
                    LineItems = new List<SessionLineItemOptions>()
                    ,
                    PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                    Mode = "payment",
					SuccessUrl = domain,
					CancelUrl = "https://localhost:7176/Customer/Cart/Index",
                };
                foreach(var item in ShoppingCartList)
                {
                    var sessionLineItem = new SessionLineItemOptions
					{
						PriceData = new SessionLineItemPriceDataOptions
						{
							UnitAmount = (long)(item.MenuItem.Price * 100),
							Currency = "gbp",
							ProductData = new SessionLineItemPriceDataProductDataOptions
							{
								Name = $"{item.MenuItem.Name}",
								Description = item.MenuItem.Description,
							},
						},
						Quantity = item.Count
					};
                    options.LineItems.Add(sessionLineItem);
				}

                var service = new SessionService();
                Session session = service.Create(options);

                Response.Headers.Add("Location", session.Url);

                OrderHeader.SessionId = session.Id;
                OrderHeader.PaymentIntentId = session.PaymentIntentId;
                _unitOfWork.SaveChanges();
                return new StatusCodeResult(303);
            }
            return Page();
        }
    }
}
