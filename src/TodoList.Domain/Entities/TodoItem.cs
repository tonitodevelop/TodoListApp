using Todo.Domain.Common.Base;

namespace Todo.Domain.Entities
{
    public class TodoItem : BaseEntity<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; } = false;
        public int TodoListId { get; set; }
        public virtual TodoList? TodoList { get; set; }
    }
}
