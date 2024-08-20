namespace Todo.Application.Common.Dtos
{
    public class TodoListDto
    {
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        //public IEnumerable<TodoItemDto>? Items { get; set; }
    }

    public class TodoListDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public int UserId { get; set; }
        public IEnumerable<TodoItemDetailDto>? Items { get; set; }
    }
}
