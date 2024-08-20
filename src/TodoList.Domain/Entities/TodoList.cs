using Todo.Domain.Common.Base;

namespace Todo.Domain.Entities
{
    public class TodoList : BaseEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public virtual IEnumerable<TodoItem>? Items { get; set; }
    }
}
