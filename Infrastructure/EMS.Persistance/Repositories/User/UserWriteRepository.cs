using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;

namespace EMS.Persistance.Repositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
