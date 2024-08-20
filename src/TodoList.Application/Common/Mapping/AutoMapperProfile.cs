using AutoMapper;
using Todo.Application.Common.Dtos;
using Todo.Domain.Entities;

namespace Todo.Application.Common.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<TodoItem, TodoItemDetailDto>().ReverseMap();
            CreateMap<TodoList, TodoListDto>().ReverseMap();
            CreateMap<TodoList, TodoListDetailDto>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginResponse>().ReverseMap();
            CreateMap<ApplicationUser, LoginRequest>().ReverseMap();
            CreateMap<ApplicationUser, UserDetailDto>().ReverseMap();
        }
    }
}
