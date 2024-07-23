﻿using EMS.Domain.Common;
using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Contexts
{
    public class EMSDbContext : DbContext
    {
        public EMSDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreateTime = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.LastModified = DateTime.UtcNow,
                    EntityState.Deleted => data.Entity.LastModified = DateTime.UtcNow, // Or any other logic you need
                    _ => data.Entity.LastModified // Ensure all other states are handled, even if they do nothing
                };
            }

            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
