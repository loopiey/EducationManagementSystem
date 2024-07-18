using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMS.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Course> Courses { get; set; }
        Task<int> SaveChangesAsync();
    }

    public interface IUserService
    {
        Task<bool> RegisterUser(User user);
        Task<User> LoginUser(string email, string password);
    }
}
