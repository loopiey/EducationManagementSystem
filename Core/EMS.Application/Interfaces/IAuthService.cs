using EMS.Application.DTO.EMS.API.DTOs;
using EMS.Domain.Entities;

namespace EMS.Application.Interfaces
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterUserDto registerDto);
        Task<string> LoginAsync(LoginUserDto loginDto);
    }
}
