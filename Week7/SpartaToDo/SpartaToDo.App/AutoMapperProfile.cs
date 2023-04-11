using AutoMapper;
using SpartaToDo.App.Models;

namespace SpartaToDo.App
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateToDoVM, ToDo>();
            CreateMap<ToDo, EditToDoVM>();
            CreateMap<ToDo, ToDoVM>();
            CreateMap<ToDoVM, ToDo>();
            CreateMap<EditToDoVM, ToDo>();
        }
    }
}
