using EMS.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace EMS.Application.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
