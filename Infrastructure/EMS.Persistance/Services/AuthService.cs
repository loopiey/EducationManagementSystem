using BCrypt.Net;
using EMS.Application.DTO.EMS.API.DTOs;
using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EMS.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly EMSDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(EMSDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User> RegisterAsync(RegisterUserDto registerDto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == registerDto.Email);
            if (existingUser != null)
            {
                throw new InvalidOperationException("Email is already registered.");
            }

            var user = new User
            {
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Phone = registerDto.Phone,
                Email = registerDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDto.Password),
                UserType = registerDto.UserType
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<string> LoginAsync(LoginUserDto loginDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                throw new UnauthorizedAccessException("Invalid credentials.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.UserType)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
