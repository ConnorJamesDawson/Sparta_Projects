using Microsoft.AspNetCore.Mvc;
using RestaurantWebApp.DataAccess.Repository.IRepository;

namespace RestaurantWebApp.App.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MenuItemController : Controller
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public MenuItemController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
    {
        _unitOfWork = unitOfWork;
        _webHostEnvironment = webHostEnvironment;
    }
    [HttpGet]
    public IActionResult Get()
    {
        var menuItemList = _unitOfWork.MenuItem.GetAll(includeProperties: "Category,FoodType");

        return Json( new { data = menuItemList});
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var objFromDb= _unitOfWork.MenuItem.GetByIdFirstOrDefault(x => x.Id == id);
        var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, objFromDb.ImageURL.TrimStart('\\'));

        if (System.IO.File.Exists(oldImagePath))
        {
            System.IO.File.Delete(oldImagePath);
        }
        _unitOfWork.MenuItem.Delete(objFromDb);
        _unitOfWork.SaveChanges();
        return Json(new { success = true, message = "Delete successful." });
    }
}
