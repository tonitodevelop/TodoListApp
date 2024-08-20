using Todo.Application.Common.Dtos;

namespace Todo.Application.Services
{
    public interface ITodoListService
    {
        Task<TodoListDetailDto> CreateTodoListAsync(TodoListDto todoListDto);
        Task<TodoListDetailDto> UpdateTodoListAsync(TodoListDetailDto todoListDetailDto);
        Task<IEnumerable<TodoListDetailDto>> GetTodoListByUser(int userId);
        Task<TodoListDetailDto> GetListByIdAsync(int id);
        Task<IEnumerable<TodoListDetailDto>> GetAllListAsync();
        Task<bool> DeleteTodoListByListId(IEnumerable<int> ids);
    }
}
