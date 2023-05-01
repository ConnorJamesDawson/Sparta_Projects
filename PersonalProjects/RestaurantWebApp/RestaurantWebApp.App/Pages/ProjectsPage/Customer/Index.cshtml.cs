using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.ProjectsPage.Customer
{
    public class IndexModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;

		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IEnumerable<Projects> ProjectList { get; set; }

		public void OnGet()
        {
			ProjectList = _unitOfWork.Project.GetAll();	
        }
    }
}
