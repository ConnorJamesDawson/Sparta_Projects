using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Utility;

namespace RestaurantWebApp.App.Controllers;
[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public OrderController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    [HttpGet]
    [Authorize]
    public IActionResult Get(string? status = null)
    {
        var OrderHeaderList = _unitOfWork.OrderHeader.GetAll(includeProperties: "ApplicationUser");

        switch(status)
        {
            case "cancelled":
                OrderHeaderList = OrderHeaderList.Where(oh=> oh.Status == SD.StatusCancelled || oh.Status == SD.StatusRejected);
                break;
            case "completed":
                OrderHeaderList = OrderHeaderList.Where(oh => oh.Status == SD.StatusCompleted);
                break;
            case "ready":
                OrderHeaderList = OrderHeaderList.Where(oh => oh.Status == SD.StatusReady);
                break;
            case "inprocess":
                OrderHeaderList = OrderHeaderList.Where(oh => oh.Status == SD.StatusSubmitted || oh.Status == SD.StatusInProcess);
                break;
        }
        return Json( new { data = OrderHeaderList });
    }
}
