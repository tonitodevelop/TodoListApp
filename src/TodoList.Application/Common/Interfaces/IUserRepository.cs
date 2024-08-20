using Todo.Domain.Entities;

namespace Todo.Application.Common.Interfaces
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        Task<ApplicationUser> GetLoginByCredentials(ApplicationUser userLogin);
    }
}
