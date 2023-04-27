using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using RestaurantWebApp.Models.ViewModel;
using RestaurantWebApp.Utility;

namespace RestaurantWebApp.App.Pages.Admin.Order
{
    [Authorize(Roles = $"{SD.ManagerRole},{SD.KitchenRole}")]
    public class ManageOrderModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public List<OrderDetailVM> OrderDetailVM { get; set; }

        public ManageOrderModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            OrderDetailVM = new();
            List<OrderHeader> orderHeaders= _unitOfWork.OrderHeader.GetAll(
                oh=>oh.Status == SD.StatusSubmitted || 
                oh.Status == SD.StatusInProcess).ToList();

            foreach(OrderHeader header in orderHeaders)
            {
                OrderDetailVM individual = new OrderDetailVM()
                {
                    OrderHeader = header,
                    OrderDetails = _unitOfWork.OrderDetail.GetAll(od=>od.OrderId == header.Id).ToList()
                };
                OrderDetailVM.Add(individual);
            }
        }

        public IActionResult OnPostOrderInProcess(int orderId) 
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusInProcess);
            _unitOfWork.SaveChanges();

            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderReady(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusReady);
            _unitOfWork.SaveChanges();

            return RedirectToPage("ManageOrder");
        }

        public IActionResult OnPostOrderCancel(int orderId)
        {
            _unitOfWork.OrderHeader.UpdateStatus(orderId, SD.StatusCancelled);
            _unitOfWork.SaveChanges();

            return RedirectToPage("ManageOrder");
        }
    }
}
