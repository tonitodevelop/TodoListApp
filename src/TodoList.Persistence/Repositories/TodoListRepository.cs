using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Persistence.Data;

namespace Todo.Persistence.Repositories
{
    public class TodoListRepository : Repository<TodoList>, ITodoListRepository
    {
        private readonly TodoListDbContext _dbContext;

        public TodoListRepository(TodoListDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodoList> FindTodoListByTodoListWithItems(int todoId)
        {
            //var entity = await _entities.Where(x => x.Id == todoId).Include(x => x.Items!.Where(i => i.IsCompleted == false)).FirstOrDefaultAsync();
            var entity = await _entities.Where(x => x.Id == todoId).Include(x => x.Items).FirstOrDefaultAsync();
            return entity!;
        }

        public async Task<IEnumerable<TodoList>> FindAllTodoListByUser(int userId)
        {
            var list = await _entities.Where(x => x.UserId == userId).Include(x => x.Items).AsNoTracking().ToListAsync();
            return list;
        }

        public async Task<bool> DeleteTodoListByListId(IEnumerable<int> todoIds)
        {
            //TODO ELiminamos los todoList por la lista de ids
            var todoList = await _entities.Where(x => todoIds.Contains(x.Id)).ToListAsync();
            _entities.RemoveRange(todoList);

            return todoIds.Count() > 0;

        }
    }
}
