using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Abstractions
{
    public interface IUserService
    {
        List<User> GetUsers();
    }
}
