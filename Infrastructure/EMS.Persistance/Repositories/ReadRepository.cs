using EMS.Application.Interfaces;
using EMS.Domain.Common;
using EMS.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;

using System.Linq.Expressions;

namespace EMS.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly EMSDbContext _context;
        public ReadRepository(EMSDbContext context)
        {
            _context = context;
        }
        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);

        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }
  

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method);
            if (!tracking) 
                query = query.AsNoTracking();
            return query;
        }
    }
}
