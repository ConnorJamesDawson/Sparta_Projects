using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.ProjectsPage.Customer
{
    public class ViewDetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public ViewDetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [BindProperty]
        public Projects Project { get; set; }
        public void OnGet(int id)
        {
            Project = _unitOfWork.Project.GetByIdFirstOrDefault(x => x.Id == id);
        }
    }
}
