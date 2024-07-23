using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Student : User
    {
        public ICollection<Course>? EnrolledCourses { get; set; }
    }
}
