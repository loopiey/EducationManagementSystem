using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Services
{
    public class UserService : IUserService
    {
        private readonly IUserReadRepository _userReadRepo;
        private readonly IUserWriteRepository _userWriteRepo;

        public UserService(IUserReadRepository userReadRepo, IUserWriteRepository userWriteRepo)
        {
            _userReadRepo = userReadRepo;
            _userWriteRepo = userWriteRepo;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userReadRepo.GetAll().Where(u => !u.IsDeleted).ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid id)
        {
            var user = await _userReadRepo.GetByIdAsync(id.ToString());
            if (user == null || user.IsDeleted)
            {
                return null;
            }
            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = Guid.NewGuid();
            await _userWriteRepo.AddAsync(user);
            await _userWriteRepo.SaveAsync();
            return user;
        }

        public async Task<bool> UpdateUserAsync(Guid id, User user)
        {
            var existingUser = await _userReadRepo.GetByIdAsync(id.ToString());
            if (existingUser == null || existingUser.IsDeleted)
            {
                return false;
            }

            existingUser.Name = user.Name;
            existingUser.Surname = user.Surname;
            existingUser.Email = user.Email;
            existingUser.Phone = user.Phone;
            existingUser.UserType = user.UserType;

            _userWriteRepo.Update(existingUser);
            await _userWriteRepo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteUserAsync(Guid id)
        {
            var user = await _userReadRepo.GetByIdAsync(id.ToString());
            if (user == null || user.IsDeleted)
            {
                return false;
            }

            user.IsDeleted = true;
            _userWriteRepo.Update(user);
            await _userWriteRepo.SaveAsync();
            return true;
        }
    }
}
