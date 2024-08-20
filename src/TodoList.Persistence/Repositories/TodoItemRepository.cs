using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Persistence.Data;

namespace Todo.Persistence.Repositories
{
    public class TodoItemRepository : Repository<TodoItem>, ITodoItemRepository
    {
        private readonly TodoListDbContext _dbContext;
        public TodoItemRepository(TodoListDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodoItem> ChangeItemToComplete(int itemId)
        {
            var item = await FindByConditionalAsync(i => i.Id == itemId);
            item.IsCompleted = true;
            _entities.Update(item);
            return item;
        }

        public async Task<bool> DeleteTodoItemByItemsId(IEnumerable<int> itemsIds)
        {
            var items = await _entities.Where(i => itemsIds.Contains(i.Id)).ToListAsync();
            _entities.RemoveRange(items);
            return items.Count > 0;
        }

        public async Task<IEnumerable<TodoItem>> FindAllTodoItemByTodoList(int todoListId)
        {
            var result = await _entities.Where(i => i.TodoListId == todoListId).AsNoTracking().ToListAsync();
            return result!;
        }
    }
}
