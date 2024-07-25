﻿using EMS.Domain.Entities;

namespace EMS.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> CreateUserAsync(User user);
        Task<bool> UpdateUserAsync(Guid id, User user);
        Task<bool> DeleteUserAsync(Guid id);
    }
}
