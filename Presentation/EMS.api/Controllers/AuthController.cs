using EMS.Application.DTO.EMS.API.DTOs;
using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EMS.API.Controllers
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
        public async Task<ActionResult<User>> Register(RegisterUserDto registerDto)
        {
            try
            {
                var user = await _authService.RegisterAsync(registerDto);
                return CreatedAtAction("GetUser", "Users", new { id = user.Id }, user);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto loginDto)
        {
            try
            {
                var token = await _authService.LoginAsync(loginDto);
                return Ok(new { Token = token });
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
        }
    }
}
