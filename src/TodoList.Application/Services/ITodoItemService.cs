using Todo.Application.Common.Dtos;

namespace Todo.Application.Services
{
    public interface ITodoItemService
    {
        Task<TodoItemDetailDto> GetItemByIdAsync(int id);
        Task<IEnumerable<TodoItemDetailDto>> GetAllItemAsync();
        Task<IEnumerable<TodoItemDetailDto>> GetAllItemByTodoListAsync(int todoListId);
        Task<TodoItemDetailDto> CreateTodoItemAsync(TodoItemDto todoItemDto);
        Task<TodoItemDetailDto> UpdateTodoItemAsync(TodoItemDetailDto todoItemDetailDto);
        //Task<TodoItemDetailDto> ChangeItemToComplete(int itemId, bool isCompleted);
        Task<IEnumerable<TodoItemDetailDto>> ChangeItemsToComplete(IEnumerable<int> itemsId);
        Task<bool> DeleteTodoItemByItemsId(IEnumerable<int> itemsIds);
    }
}
