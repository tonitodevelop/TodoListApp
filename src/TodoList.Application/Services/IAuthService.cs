using Todo.Application.Common.Dtos;

namespace Todo.Application.Services
{
    public interface IAuthService
    {
        Task<bool> RegisterUser(RegisterUserDto userDto);
        Task<LoginResponse> AuthenticateUser(LoginRequest loginCredential);
        Task<UserDetailDto> GetUserDetail(int id);
    }
}
