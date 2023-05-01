using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Evaluation;
using RestaurantWebApp.DataAccess.Repository.IRepository;
using RestaurantWebApp.Models;

namespace RestaurantWebApp.App.Pages.ProjectsPage.Admin
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public Projects Project { get; set; }

        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
            Project = new Projects();
        }
        public void OnGet(int? id)
        {
            if (id != null)
            {
                Project = _unitOfWork.Project.GetByIdFirstOrDefault(p => p.Id == id);
            }
        }
        public async Task<IActionResult> OnPost()
        {
            string webRootPath = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            if (Project.Id == 0) //Create
            {
                string fileNameNew = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"Images/Projects");
                var extension = Path.GetExtension(files[0].FileName);

                using (var fileStream = new FileStream(Path.Combine(uploads, fileNameNew + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                Project.ImageURL = @"\Images\Projects\" + fileNameNew + extension;
                _unitOfWork.Project.Add(Project);
                _unitOfWork.SaveChanges();
                TempData["success"] = "Menu Item successfully added!";
            }
            else //Update/Edit
            {
                var objFromDb = _unitOfWork.Project.GetByIdFirstOrDefault(mi => mi.Id == Project.Id);
                if (files.Count > 0)// A file has been uploaded
                {
                    string fileNameNew = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"Images/Projects");
                    var extension = Path.GetExtension(files[0].FileName);
                    if(objFromDb.ImageURL != null)
                    {
                        var oldImagePath = Path.Combine(webRootPath, objFromDb.ImageURL.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(uploads, fileNameNew + extension), FileMode.Create))
                    {
                        files[0].CopyTo(fileStream);
                    }
                    Project.ImageURL = @"\Images\Projects\" + fileNameNew + extension;
                }
                else
                {
                    Project.ImageURL = objFromDb.ImageURL;
                }
                _unitOfWork.Project.Update(Project);
                _unitOfWork.SaveChanges();
            }

            return RedirectToPage("/ProjectsPage/Customer/Index");
        }
    }
}
