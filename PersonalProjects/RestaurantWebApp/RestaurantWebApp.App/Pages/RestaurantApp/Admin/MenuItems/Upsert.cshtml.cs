using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantWebApp.DataAccess.Data;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.RestaurantApp.Admin.MenuItems
{
    [BindProperties]
    public class UpsertModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MenuItem MenuItem { get; set; }
        public IEnumerable<SelectListItem> CategoryList { get; set; }
        public IEnumerable<SelectListItem> FoodTypeList { get; set; }

        public UpsertModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            MenuItem = new MenuItem();
        }
        public void OnGet(int? id)
        {
            if(id != null)
            {
                MenuItem = _unitOfWork.MenuItem.GetByIdFirstOrDefault(mi => mi.Id == id);
            }
            CategoryList = _unitOfWork.Category.GetAll().Select(i=> new SelectListItem()
            {
                Text= i.Name,
                Value= i.Id.ToString()
            });
            FoodTypeList = _unitOfWork.FoodType.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Name,
                Value = i.Id.ToString()
            });
        }

        public async Task<IActionResult> OnPost()
        {

            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if(MenuItem.Id == 0) //Create
            {
                string fileNameNew = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"Images/menuItems");
                var extension = Path.GetExtension(files[0].FileName);

                using(var fileStream = new FileStream(Path.Combine(uploads, fileNameNew+extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                MenuItem.ImageURL = @"\Images\MenuItems\"+fileNameNew+extension;
                _unitOfWork.MenuItem.Add(MenuItem);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Menu Item successfully added!";
            }
            else //Update/Edit
            {
                var objFromDb = _unitOfWork.MenuItem.GetByIdFirstOrDefault(mi => mi.Id == MenuItem.Id);
                if(files.Count > 0)// A file has been uploaded
                {
                    string fileNameNew = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images/menuItems");
                    var extension = Path.GetExtension(files[0].FileName);

                    var oldImagePath = Path.Combine(webRootPath, objFromDb.ImageURL.TrimStart('\\'));

                    if(System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileNameNew + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    MenuItem.ImageURL = @"\Images\MenuItems\" + fileNameNew + extension;
                }
                else
                {
                    MenuItem.ImageURL = objFromDb.ImageURL;
                }
                _unitOfWork.MenuItem.Update(MenuItem);
                _unitOfWork.SaveChanges();
            }

            return RedirectToPage("Index");
        }
    }
}
