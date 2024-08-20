namespace Todo.Application.Common.Dtos
{
    public class TodoItemDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int TodoListId { get; set; }
        public bool IsCompleted { get; set; } = false;
    }

    public class TodoItemDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public int TodoListId { get; set; }
    }
}
