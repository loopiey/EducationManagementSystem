using EMS.API.DTOs;
using EMS.Domain.Entities;

namespace EMS.Application.Interfaces
{
    public interface ICourseService
    {
        Task<Course> CreateCourseAsync(CreateCourseDto createCourseDto);
        Task<Course> GetCourseByIdAsync(Guid id);
        Task<bool> UpdateCourseAsync(Guid id, UpdateCourseDto updateCourseDto);
        Task<bool> DeleteCourseAsync(Guid id);
    }

}
