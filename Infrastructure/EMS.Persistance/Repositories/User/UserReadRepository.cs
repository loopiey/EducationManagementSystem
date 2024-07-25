using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;

namespace EMS.Persistance.Repositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
