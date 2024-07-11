using EMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EMS.Persistance
{
    public class EMSContext : DbContext
    {
        public EMSContext(DbContextOptions<EMSContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        // Add other DbSets here

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Model configurations go here
        }
    }
}
