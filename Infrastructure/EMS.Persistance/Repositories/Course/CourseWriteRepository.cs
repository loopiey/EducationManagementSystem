using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;

namespace EMS.Persistance.Repositories
{
    public class CourseWriteRepository : WriteRepository<Course>, ICourseWriteRepository
    {
        public CourseWriteRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
