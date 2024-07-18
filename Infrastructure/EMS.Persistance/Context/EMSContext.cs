using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistance.Context
{
    public class EMSContext(DbContextOptions<EMSContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        // Add other DbSets here
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Model configurations go here
        }
    }
}
