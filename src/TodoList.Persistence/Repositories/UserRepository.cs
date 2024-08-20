using Microsoft.EntityFrameworkCore;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;
using Todo.Persistence.Data;

namespace Todo.Persistence.Repositories
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        private readonly TodoListDbContext _dbContext;

        public UserRepository(TodoListDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ApplicationUser> GetLoginByCredentials(ApplicationUser userLogin)
        {
            var result = await _entities.FirstOrDefaultAsync(u => u.UserName == userLogin.UserName);
            return result!;
        }
    }
}
