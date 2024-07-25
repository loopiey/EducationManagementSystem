using EMS.Application.Interfaces;
using EMS.Application.Services;
using EMS.Persistance.Contexts;
using EMS.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EMS.Persistance.Services
{
    public static class ServiceRegistration
    {
        public static void AddPersistanceService(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EMSDbContext>(options => options.UseNpgsql(connectionString));

            services.AddScoped<ICourseReadRepository, CourseReadRepository>();
            services.AddScoped<ICourseWriteRepository, CourseWriteRepository>();
            services.AddScoped<IUserReadRepository, UserReadRepository>();
            services.AddScoped<IUserWriteRepository, UserWriteRepository>();

            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICourseService, CourseService>();

        }
    }
}
