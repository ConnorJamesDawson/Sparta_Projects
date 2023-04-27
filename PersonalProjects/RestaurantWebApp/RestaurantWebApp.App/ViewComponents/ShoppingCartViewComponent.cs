using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Utility;
using System.Security.Claims;

namespace RestaurantWebApp.App.ViewComponents;

public class ShoppingCartViewComponent : ViewComponent
{
    private readonly IUnitOfWork _unitOfWork;

    public ShoppingCartViewComponent(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var claimsIdentity = (ClaimsIdentity)User.Identity;
        var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
        int count = 0;
        if (claim != null)
        {
            if(HttpContext.Session.GetInt32(SD.SessionCart) != null)
            {
                return View(HttpContext.Session.GetInt32(SD.SessionCart));
            }
            else
            {
                count = _unitOfWork.ShoppingCart.GetAll(sc => sc.ApplicationUserId == claim.Value).ToList().Count;
                HttpContext.Session.SetInt32(SD.SessionCart, count);
                return View(count);
            }
        }
        else
        {
            HttpContext.Session.Clear();
            return View(count);
        }
    }
}
