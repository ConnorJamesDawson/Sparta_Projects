using SpartaToDo.App.Models.ViewModels;
using SpartaToDo.App.Models;

namespace SpartaToDo.App.Service
{
    public interface IToDoService
    {
        Task<ServiceResponce<IEnumerable<ToDoVM>>> GetTodoItemsAsync(string? filter = null);
        Task<ServiceResponce<ToDoVM>> GetTodoItemAsync(int id);
        Task<ServiceResponce<ToDoVM>> GetDetailsAsync(int? id);
        Task<ServiceResponce<ToDoVM>> CreateTodoAsync(CreateToDoVM createTodoVM);
        Task<ServiceResponce<ToDoVM>> EditTodoAsync(int? id, ToDoVM todoVM);
        Task<ServiceResponce<ToDoVM>> UpdateTodoCompleteAsync(int id, MarkCompleteVM markCompleteVM);
        Task<ServiceResponce<ToDoVM>> DeleteTodoAsync(int? id);
    }
}
