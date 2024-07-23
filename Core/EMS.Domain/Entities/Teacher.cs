﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Domain.Entities
{
    public class Teacher : User
    {
        public ICollection<Course>? CoursesTaught { get; set; }
    }
}
