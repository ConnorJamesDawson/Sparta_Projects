using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Service;

namespace SpartaToDo.App.Controllers
{
    public class ToDoItemsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IToDoService _service;

        public ToDoItemsController(IMapper mapper, IToDoService serice)
        {
            _mapper = mapper;
            _service = serice;
        }

        // GET: ToDoItems
        public async Task<IActionResult> Index(string? filter)
        {
            var responce = await _service.GetTodoItemsAsync(filter);

            if (responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // GET: ToDoItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var responce = await _service.GetDetailsAsync(id);

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateToDoVM createToDoVM)
        {
            if (ModelState.IsValid)
            {
                var responce = await _service.CreateTodoAsync(createToDoVM);
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
        public async Task<IActionResult> Edit(int id)
        {
            var responce = await _service.GetTodoItemAsync(id);

            if(responce.Success)
            {
                return View(responce.Data);
            }

            return Problem(responce.Message);
        }

        // POST: ToDoItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoVM toDoVM)
        {
            var responce = await _service.EditTodoAsync(id, toDoVM);

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(toDoVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateTodoComplete(int id, MarkCompleteVM markCompleteVM)
        {
            var responce = await _service.UpdateTodoCompleteAsync(id, markCompleteVM);

            if(responce.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return Problem(responce.Message);
        }

        // GET: ToDoItems/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var responce = await _service.GetTodoItemAsync(id);

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
            var responce = await _service.DeleteTodoAsync(id);

            if(responce.Success)
            {
                return RedirectToAction(nameof(Index));
            }

            return Problem(responce.Message);
        }
    }
}
