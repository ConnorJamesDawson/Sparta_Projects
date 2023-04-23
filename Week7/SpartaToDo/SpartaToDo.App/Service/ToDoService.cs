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

        public async Task<ServiceResponce<ToDoVM>> CreateTodoAsync(Spartan? user, CreateToDoVM createTodoVM)
        {
            var responce = new ServiceResponce<ToDoVM>();
            if(_context == null)
            {
                responce.Success = false;
                responce.Message = "Cannot find the Database assigned";
                return responce;
            }
            createTodoVM.Spartan = user;

            _context.Add(_mapper.Map<ToDo>(createTodoVM));

            await _context.SaveChangesAsync();

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> DeleteTodoAsync(Spartan? user, int? id)
        {
            var responce = new ServiceResponce<ToDoVM>();

            if (_context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = "Entity set 'SpartaToDoContext.ToDoItems'  is null.";
                return responce;
            }

            responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                .Where(td => td.SpartanId == user!.Id && td.Id == id)
                .FirstOrDefaultAsync());
            
            if (responce.Data != null)
            {
                _context.ToDoItems.Remove(_mapper.Map<ToDo>(responce.Data));
            }

            await _context.SaveChangesAsync();

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> EditTodoAsync(Spartan? user, int? id, ToDoVM todoVM, string role = "Trainee")
        {
            var responce = new ServiceResponce<ToDoVM>();
            if (id != todoVM.Id)
            {
                responce.Success = false;
                responce.Message = $"Id given {id} does not match Id {todoVM.Id}";
                return responce;
            }
            if(role == "Trainee")
            {
                var todo = await _context.ToDoItems
                .AsNoTracking()
                .FirstOrDefaultAsync(td => td.Id == id);

                if (todo.SpartanId != user.Id)
                {
                    responce.Success = false;
                    responce.Message = $"Id given {id} does not match Id {todoVM.Id}";
                    return responce;
                }
            }


            todoVM.Spartan = user;
            todoVM.SpartanId = user!.Id;

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

        public async Task<ServiceResponce<ToDoVM>> GetDetailsAsync(Spartan? user, int? id, string role = "Trainee")
        {
            var responce = new ServiceResponce<ToDoVM>();

            if (id == null || _context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = $"Id given is null, please give an actual Id";
                return responce;
            }

            if (ToDoExists((int)id))
            {
                if(role == "Trainee")
                {
                    responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                                    .FirstOrDefaultAsync(m => m.Id == id && m.SpartanId == user!.Id));


                    if (responce.Data == null)
                    {
                        responce.Success = false;
                        responce.Message = $"Found ToDoItem but user ID doen not match";
                        return responce;
                    }
                    return responce;
                }
                else if(role == "Trainer")
                {
                    responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                    .FirstOrDefaultAsync(m => m.Id == id));

                    return responce;
                }

            }

            responce.Success = false;
            responce.Message = "Could not find ToDoItem in database";

            return responce;
        }

        public async Task<ServiceResponce<ToDoVM>> GetTodoItemAsync(Spartan? user, int id, string role = "Trainee")
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
                if(role == "Trainee")
                {
                    responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                        .FirstOrDefaultAsync(m => m.Id == id && m.SpartanId == user!.Id));

                    if (responce.Data == null)
                    {
                        responce.Success = false;
                        responce.Message = $"Found ToDoItem but user ID doen not match";
                        return responce;
                    }

                    return responce;
                }
                else if(role == "Trainer")
                {
                    responce.Data = _mapper.Map<ToDoVM>(await _context.ToDoItems
                        .FirstOrDefaultAsync(m => m.Id == id));
                    return responce;
                }

            }

            responce.Success = false;
            responce.Message = "Could not find ToDoItem in database";

            return responce;
        }

        public async Task<ServiceResponce<IEnumerable<ToDoVM>>> GetTodoItemsAsync(Spartan? user, string role = "Trainee", string? filter = null)
        {
            var responce = new ServiceResponce<IEnumerable<ToDoVM>>();
            if (_context.ToDoItems == null)
            {
                responce.Success = false;
                responce.Message = ("There are no ToDO items");
                return responce;
            }

            if (user == null)
            {
                responce.Success = false;
                responce.Message = ("The user is null");
                return responce;
            }

            List<ToDo> todoItems = new();
            if (role == "Trainee")
            {
                todoItems = await _context.ToDoItems.Where(td => td.SpartanId == user!.Id).ToListAsync();
            }
            if (role == "Trainer")
            {
                todoItems = await _context.ToDoItems.Include(td => td.Spartan).ToListAsync();
            }

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

        public async Task<ServiceResponce<ToDoVM>> UpdateTodoCompleteAsync(Spartan? user, int id, MarkCompleteVM markCompleteVM)
        {
            var responce = new ServiceResponce<ToDoVM>();
            if (id != markCompleteVM.Id)
            {
                responce.Success = false;
                responce.Message = $"Id given {id} does not match Id {markCompleteVM.Id}";
                return responce;
            }
            ToDo todo = null;

            if(ToDoExists(id))
            {
                todo = await _context.ToDoItems.FirstOrDefaultAsync(m => m.Id == id && m.SpartanId == user!.Id);

                if (todo == null)
                {
                    responce.Success = false;
                    responce.Message = $"Found Item but User Id does not match";
                    return responce;
                }
            }
            else
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
