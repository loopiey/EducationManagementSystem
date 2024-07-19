﻿using EMS.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Repositories
{
    public interface IWriteRepository <T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> data);
        Task<bool> UpdateAsync(T model);
        bool Delete(T model);
        bool Delete(string id);
        Task<int> SaveAsync();
    }
}
