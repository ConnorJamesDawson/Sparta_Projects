using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using RestaurantWebApp.Utility;
using Stripe.Checkout;

namespace RestaurantWebApp.App.Pages.RestaurantApp.Customer.Cart
{
    public class OrderConfirmationModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public IEnumerable<ShoppingCart> ShoppingCartList { get; set; }
		public int OrderId { get; set; }
		public OrderConfirmationModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet(int id)
        {
			OrderHeader orderHeader = _unitOfWork.OrderHeader.GetByIdFirstOrDefault(oh=> oh.Id == id);
			if(orderHeader.SessionId != null)
			{
				var service = new SessionService();
				Session session = service.Get(orderHeader.SessionId);
				if(session.PaymentStatus.ToLower() == "paid")
				{
					orderHeader.Status = SD.StatusSubmitted;
					_unitOfWork.SaveChanges();
				}
			}
				List<ShoppingCart> shoppingCarts = _unitOfWork.ShoppingCart.GetAll(sc=> sc.ApplicationUserId == orderHeader.UserId).ToList();
				_unitOfWork.ShoppingCart.DeleteRange(shoppingCarts);
				_unitOfWork.SaveChanges();
				OrderId = id;
        }
    }
}
