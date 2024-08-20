using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Common.Base;
using Todo.Persistence.Data;

namespace Todo.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity<int>
    {
        public readonly TodoListDbContext _context;
        public readonly DbSet<T> _entities;

        public Repository(TodoListDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            T? result = null;
            try
            {
                await _entities.AddAsync(entity);
                result = entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se logró insertar el registro. {ex}");
            }
            return result;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            T? result = null;
            try
            {
                await Task.Run(() => _entities.Remove(entity));
                result = entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se logró eliminar el registro. {ex}");
            }
            return result;
        }

        public async Task<IQueryable<T>> FindAllAsync(bool trackChanges = true)
        {
            IQueryable<T>? result = null;
            try
            {
                result = trackChanges ? await Task.Run(() => _entities.AsNoTracking()) :
                    await Task.Run(() => _entities);
            }
            catch (Exception ex)
            {
                throw new Exception($"No se lograron obtener los registros. {ex}");
            }
            return result;
        }

        public async Task<T> FindByConditionalAsync(Expression<Func<T, bool>> expression, bool trackChanges = true)
        {
            T? result = null;
            try
            {
                result = trackChanges ? await Task.Run(() => _entities.Where(expression).AsNoTracking().FirstOrDefaultAsync())
                                        : await Task.Run(() => _entities.Where(expression).FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new Exception($"No se logro obtener el registro. {ex}");
            }
            return result!;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            T? result = null;
            try
            {
                await Task.Run(() => _entities.Update(entity));
                result = entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"No se logro actualizar el registro. {ex}");
            }
            return result;
        }
    }
}
