using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
        Task<IEnumerable<TodoItem>> FindAllTodoItemByTodoList(int todoListId);
        Task<TodoItem> ChangeItemToComplete(int itemId);

        Task<bool> DeleteTodoItemByItemsId(IEnumerable<int> itemsIds);
    }
}