namespace Todo.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ITodoListRepository TodoListRepository { get; }
        ITodoItemRepository TodoItemRepository { get; }
        IUserRepository UserRepository { get; }
        Task<int> SaveChangesAsync();

    }
}
