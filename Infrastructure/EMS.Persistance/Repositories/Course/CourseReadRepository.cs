using EMS.Application.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Repositories
{
    public class CourseReadRepository : ReadRepository<Course>, ICourseReadRepository
    {
        public CourseReadRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
