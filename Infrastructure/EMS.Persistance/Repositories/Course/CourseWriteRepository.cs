using EMS.Application.Repositories;
using EMS.Domain.Entities;
using EMS.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Repositories
{
    public class CourseWriteRepository : WriteRepository<Course>, ICourseWriteRepository
    {
        public CourseWriteRepository(EMSDbContext context) : base(context)
        {
        }
    }
}
