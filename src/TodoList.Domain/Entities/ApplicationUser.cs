using Todo.Domain.Common.Base;

namespace Todo.Domain.Entities
{
    public class ApplicationUser : BaseEntity<int>
    {
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual IEnumerable<TodoList>? TodoLists { get; set; }
    }
}
