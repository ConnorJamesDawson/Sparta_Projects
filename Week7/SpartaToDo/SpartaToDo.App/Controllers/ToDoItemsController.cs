using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Service;

namespace SpartaToDo.App.Controllers
{
    [Authorize]
    public class ToDoItemsController : Controller
    {
        private readonly IToDoService _service;
        private readonly UserManager<Spartan> _userManager;

        public ToDoItemsController(IToDoService serice, UserManager<Spartan> userManager)
        {
            _service = serice;
            _userManager = userManager;
        }

        // GET: ToDoItems
        [Authorize(Roles = "Trainee, Trainer")]
        public async Task<IActionResult> Index(string? filter)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.GetTodoItemsAsync(currentUser, GetRole() , filter);

            if (responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // GET: ToDoItems/Details/5
        [Authorize(Roles = "Trainee, Trainer")]
        public async Task<IActionResult> Details(int? id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.GetDetailsAsync(currentUser, id, GetRole());

            if (responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // GET: ToDoItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Trainee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoVM createToDoVM)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            if (ModelState.IsValid)
            {
                var responce = await _service.CreateTodoAsync(currentUser, createToDoVM);
                if(responce.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return Problem(responce.Message);
                }
            }
            return View(createToDoVM);
        }

        // GET: ToDoItems/Edit/5
        [Authorize(Roles = "Trainee, Trainer")]
        public async Task<IActionResult> Edit(int id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.GetTodoItemAsync(currentUser, id, GetRole());

            if(responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Trainee, Trainer")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoVM toDoVM)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.EditTodoAsync(currentUser, id, toDoVM, GetRole());

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(toDoVM);
        }
        [Authorize(Roles = "Trainee")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTodoComplete(int id, MarkCompleteVM markCompleteVM)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.UpdateTodoCompleteAsync(currentUser, id, markCompleteVM);

            if(responce.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return Problem(responce.Message);
        }

        // GET: ToDoItems/Delete/5
        [Authorize(Roles = "Trainee")]
        public async Task<IActionResult> Delete(int id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.GetTodoItemAsync(currentUser, id);

            if (responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // POST: ToDoItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currentUser = await _userManager.GetUserAsync(HttpContext.User);

            var responce = await _service.DeleteTodoAsync(currentUser, id);

            if(responce.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return Problem(responce.Message);
        }

        private string? GetRole()
        {
            return HttpContext.User.IsInRole("Trainee") ? "Trainee" : "Trainer";
        }
    }
}
