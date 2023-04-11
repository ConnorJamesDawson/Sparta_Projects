using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SpartaToDo.App.Data;
using SpartaToDo.App.Models;
using SpartaToDo.App.Models.ViewModels;

namespace SpartaToDo.App.Service
{
    public class ToDoService : IToDoService
    {
        private readonly SpartaToDoContext _context;
        private readonly IMapper _mapper;

        public ToDoService(SpartaToDoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponce<ToDoVM>> CreateTodoAsync(CreateToDoVM createTodoVM)
        {
            var responce = new ServiceResponce<ToDoVM>();
            if(_context == null)
            {
                responce.Success = false;
                responce.Message = "Cannot find the Database assigned";
                return responce;
            }

            _context.Add(_mapper.Map<ToDo>(createTodoVM));

            await _context.SaveChangesAsync();

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> DeleteTodoAsync(int? id)
        {
            var responce = new ServiceResponce<ToDoVM>();

            if (_context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = "Entity set 'SpartaToDoContext.ToDoItems'  is null.";
                return responce;
            }

            responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems.FindAsync(id));
            
            if (responce.Data != null)
            {
                _context.ToDoItems.Remove(await _context.ToDoItems.FindAsync(id));
            }

            await _context.SaveChangesAsync();

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> EditTodoAsync(int? id, ToDoVM todoVM)
        {
            var responce = new ServiceResponce<ToDoVM>();
            if (id != todoVM.Id)
            {
                responce.Success = false;
                responce.Message = $"Id given {id} does not match Id {todoVM.Id}";
                return responce;
            }

            try
            {
                _context.Update(_mapper.Map<ToDo>(todoVM));

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoExists(todoVM.Id))
                {
                    responce.Success = false;
                    responce.Message = $"Item does not exist in the database";
                    return responce;
                }
                else
                {
                    throw;
                }
            }
            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> GetDetailsAsync(int? id)
        {
            var responce = new ServiceResponce<ToDoVM>();

            if (id == null || _context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = $"Id given is null, please give an actual Id";
                return responce;
            }

            responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                .FirstOrDefaultAsync(m => m.Id == id));

            if (responce.Data == null)
            {
                responce.Success = false;
                responce.Message = $"Could not find Item with Id given {id}";
                return responce;
            }

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> GetTodoItemAsync(int id)
        {
            var responce = new ServiceResponce<ToDoVM>();

            if (_context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = ("There are no ToDO items");
                return responce;
            }

            if(ToDoExists(id))
            {
                responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems.FindAsync(id));
                return responce;
            }

            responce.Success = false;
            responce.Message = "Could not find ToDoItem in database";

            return responce;
        }

        public async Task<ServiceResponce<IEnumerable<ToDoVM>>> GetTodoItemsAsync(string? filter = null)
        {
            var responce = new ServiceResponce<IEnumerable<ToDoVM>>();
            if (_context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = ("There are no ToDO items");
                return responce;
            }

            var todoItems = await _context.ToDoItems.ToListAsync();
            if (filter == null)
            {
                responce.Data = todoItems.Select(d => _mapper.Map<ToDoVM>(d));
                return responce;
            }

            responce.Data = todoItems
                .Where(t => t.Title.Contains(filter!, StringComparison.OrdinalIgnoreCase) ||
                (t.Description != null && t.Description.Contains(filter!, StringComparison.OrdinalIgnoreCase)))
                .Select(d => _mapper.Map<ToDoVM>(d));

            return responce;

        }

        public async Task<ServiceResponce<ToDoVM>> UpdateTodoCompleteAsync(int id, MarkCompleteVM markCompleteVM)
        {
            var responce = new ServiceResponce<ToDoVM>();
            if (id != markCompleteVM.Id)
            {
                responce.Success = false;
                responce.Message = $"Id given {id} does not match Id {markCompleteVM.Id}";
                return responce;
            }
            var todo = await _context.ToDoItems.FindAsync(id);
            if (todo == null)
            {
                responce.Success = false;
                responce.Message = $"Could not find Item with Id given {id}";
                return responce;
            }

            todo.Complete = markCompleteVM.Complete;

            await _context.SaveChangesAsync();

            return responce;
        }

        private bool ToDoExists(int id)
        {
            return (_context.ToDoItems?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
