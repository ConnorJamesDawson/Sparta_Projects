using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace RestaurantWebApp.App.Pages.Customer.HomePage
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

		public DetailsModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
        public MenuItem MenuItem { get; set; }
        [Range(1,100, ErrorMessage = "Please input a number more than 1")]
        public int Count { get; set; }
        public void OnGet(int id)
        {
            MenuItem = _unitOfWork.MenuItem.GetByIdFirstOrDefault(mi => mi.Id == id, includeProperties: "Category,FoodType");
        }
    }
}
