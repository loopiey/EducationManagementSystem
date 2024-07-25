using EMS.Domain.Common;

namespace EMS.Application.Interfaces
{
    public interface IWriteRepository <T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        bool Update(T model);
        bool Delete(T model);
        Task<bool> DeleteAsync(string id);
        Task<int> SaveAsync();
    }
}
