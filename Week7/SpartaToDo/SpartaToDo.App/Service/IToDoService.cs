using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Models;

namespace SpartaToDo.App.Service
{
    public interface IToDoService
    {
        Task<ServiceResponce<IEnumerable<ToDoVM>>> GetTodoItemsAsync(Spartan? user,string role = "Trainee", string? filter = null);
        Task<ServiceResponce<ToDoVM>> GetTodoItemAsync(Spartan? user, int id, string role = "Trainee");
        Task<ServiceResponce<ToDoVM>> GetDetailsAsync(Spartan? user, int? id, string role = "Trainee");
        Task<ServiceResponce<ToDoVM>> CreateTodoAsync(Spartan? user, CreateToDoVM createTodoVM);
        Task<ServiceResponce<ToDoVM>> EditTodoAsync(Spartan? user, int? id, ToDoVM todoVM, string role = "Trainee");
        Task<ServiceResponce<ToDoVM>> UpdateTodoCompleteAsync(Spartan? user, int id, MarkCompleteVM markCompleteVM);
        Task<ServiceResponce<ToDoVM>> DeleteTodoAsync(Spartan? user, int? id);
    }
}
