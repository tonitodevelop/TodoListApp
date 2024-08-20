using Microsoft.AspNetCore.Mvc;
using Todo.Application.Common.Dtos;
using Todo.Application.Services;

namespace Todo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser([FromBody] RegisterUserDto userDto)
        {
            var result = await _authService.RegisterUser(userDto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult> LoginUser([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.AuthenticateUser(loginRequest);
            return Ok(result);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult> GetUserById(int id)
        {
            var result = await _authService.GetUserDetail(id);
            return Ok(result);
        }
    }
}
