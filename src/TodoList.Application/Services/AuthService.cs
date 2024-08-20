using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Todo.Application.Common.Dtos;
using Todo.Application.Common.Interfaces;
using Todo.Domain.Entities;

namespace Todo.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, IConfiguration configuration = null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<LoginResponse> AuthenticateUser(LoginRequest loginCredential)
        {
            var result = new LoginResponse();
            var validations = await isValidUser(loginCredential);
            if (validations.Item1)
            {
                var user = _mapper.Map<ApplicationUser>(validations.Item2);
                result.Token = GenerateToken(user);
                result.UserName = user.UserName;
                result.UserId = user.Id;
            }
            return result;
        }

        private string GenerateToken(ApplicationUser user)
        {
            var result = string.Empty;
            //Token Headers
            var simetricsSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:key"]));
            var signinCredentials = new SigningCredentials(simetricsSecurityKey, SecurityAlgorithms.HmacSha256);
            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim("UserName", user.UserName)
            };
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials: signinCredentials
            );

            result = new JwtSecurityTokenHandler().WriteToken(token);
            return result;
        }

        private async Task<(bool, ApplicationUser)> isValidUser(LoginRequest loginCredential)
        {
            bool isValidPassword = false;
            ApplicationUser? user = await GetLoginByCredentials(loginCredential);
            if (user != null)
            {
                isValidPassword = user.Password.Equals(loginCredential.Password);
            }
            return (isValidPassword, user);
        }

        private async Task<ApplicationUser> GetLoginByCredentials(LoginRequest loginCredential)
        {
            var user = _mapper.Map<ApplicationUser>(loginCredential);
            var userByCredentials = await _unitOfWork.UserRepository.GetLoginByCredentials(user);
            return userByCredentials;
        }

        public async Task<bool> RegisterUser(RegisterUserDto userDto)
        {
            var user = _mapper.Map<ApplicationUser>(userDto);
            var userCreated = await _unitOfWork.UserRepository.CreateAsync(user);
            await _unitOfWork.SaveChangesAsync();
            return userCreated != null;
        }

        public async Task<UserDetailDto> GetUserDetail(int id)
        {
            var user = await _unitOfWork.UserRepository.FindByConditionalAsync(x => x.Id == id);
            var result = _mapper.Map<UserDetailDto>(user);
            return result;
        }
    }
}
