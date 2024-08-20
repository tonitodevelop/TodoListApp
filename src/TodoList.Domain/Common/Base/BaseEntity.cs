namespace Todo.Domain.Common.Base
{
    public abstract class BaseEntity<T>
    {
        public T? Id { get; set; }
    }
}
