using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface ITodoListRepository : IRepository<TodoList>
    {
        Task<IEnumerable<TodoList>> FindAllTodoListByUser(int userId);
        Task<TodoList> FindTodoListByTodoListWithItems(int todoId);
        Task<bool> DeleteTodoListByListId(IEnumerable<int> todoIds);
    }
}
