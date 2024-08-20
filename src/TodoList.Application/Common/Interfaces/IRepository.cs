using System.Linq.Expressions;
using Todo.Domain.Common.Base;

namespace Todo.Application.Common.Interfaces
{
    public interface IRepository<T> where T : BaseEntity<int>
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(T entity);
        Task<IQueryable<T>> FindAllAsync(bool trackChanges = true);
        Task<T> FindByConditionalAsync(Expression<Func<T, bool>> expression, bool trackChanges = true);
    }
}
