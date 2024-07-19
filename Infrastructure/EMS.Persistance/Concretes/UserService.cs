using EMS.Application.Abstractions;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Concrete
{
    public class UserService : IUserService
    {
        public List<User> GetUsers()
            =>
            [
                new() { Id = Guid.NewGuid(), Name = "Sudent", Surname = "Surname", Email = "stumail", Phone = "Phone", IsTeacher = false, Password = "Password" },
                new() { Id = Guid.NewGuid(), Name = "Teacher", Surname = "Surname", Email = "teachmail", Phone = "Phone", IsTeacher = true, Password = "Password" }
            ];
    }
}
