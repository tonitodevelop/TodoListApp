using Todo.Application.Common.Interfaces;
using Todo.Persistence.Data;

namespace Todo.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoListDbContext _dbContext;

        public UnitOfWork(TodoListDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ITodoListRepository TodoListRepository => new TodoListRepository(_dbContext);
        public ITodoItemRepository TodoItemRepository => new TodoItemRepository(_dbContext);
        public IUserRepository UserRepository => new UserRepository(_dbContext);

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
