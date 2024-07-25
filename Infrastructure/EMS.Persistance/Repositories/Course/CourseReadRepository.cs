using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;


namespace EMS.Persistance.Repositories
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        public CourseReadRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
