﻿using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EMS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserReadRepository _userReadRepo;
        private readonly IUserWriteRepository _userWriteRepo;

        public UsersController(IUserReadRepository userReadRepo, IUserWriteRepository userWriteRepo)
        {
            _userReadRepo = userReadRepo;
            _userWriteRepo = userWriteRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userReadRepo.GetAll().ToListAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            var user = await _userReadRepo.GetByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            user.Id = Guid.NewGuid();
            await _userWriteRepo.AddAsync(user);
            await _userWriteRepo.SaveAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = await _userReadRepo.GetByIdAsync(id.ToString());
            if (existingUser == null)
            {
                return NotFound();
            }

            // Update the properties of the existing user with the new values
            user.Name = userDto.Name;
            user.Surname = userDto.Surname;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;

            _userWriteRepo.Update(existingUser);
            await _userWriteRepo.SaveAsync();

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var user = await _userReadRepo.GetByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }

            //user.IsDeleted = true;
            _userWriteRepo.Delete(user);
            await _userWriteRepo.SaveAsync();

            return NoContent();
        }
    }
}
