using EMS.API.DTOs;
using EMS.Application.Interfaces;
using EMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Persistance.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseReadRepository _courseReadRepo;
        private readonly ICourseWriteRepository _courseWriteRepo;

        public CourseService(ICourseReadRepository courseReadRepo, ICourseWriteRepository courseWriteRepo)
        {
            _courseReadRepo = courseReadRepo;
            _courseWriteRepo = courseWriteRepo;
        }

        public async Task<Course> CreateCourseAsync(CreateCourseDto createCourseDto)
        {
            if (createCourseDto.Credit > 6)
            {
                throw new InvalidOperationException("Credit value cannot exceed 6.");
            }

            var course = new Course
            {
                Name = createCourseDto.Name,
                Explanation = createCourseDto.Explanation,
                IsMandatory = createCourseDto.IsMandatory,
                Credit = createCourseDto.Credit,
                TeacherId = createCourseDto.TeacherId
            };

            await _courseWriteRepo.AddAsync(course);
            await _courseWriteRepo.SaveAsync();
            return course;
        }

        public async Task<Course> GetCourseByIdAsync(Guid id)
        {
            var course = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (course == null || course.IsDeleted)
            {
                return null;
            }
            return course;
        }

        public async Task<bool> UpdateCourseAsync(Guid id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (existingCourse == null || existingCourse.IsDeleted)
            {
                return false;
            }

            if (updateCourseDto.Credit > 6)
            {
                throw new InvalidOperationException("Credit value cannot exceed 6.");
            }

            existingCourse.Name = updateCourseDto.Name;
            existingCourse.Explanation = updateCourseDto.Explanation;
            existingCourse.IsMandatory = updateCourseDto.IsMandatory;
            existingCourse.Credit = updateCourseDto.Credit;
            existingCourse.TeacherId = updateCourseDto.TeacherId;

            _courseWriteRepo.Update(existingCourse);
            await _courseWriteRepo.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteCourseAsync(Guid id)
        {
            var course = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (course == null || course.IsDeleted)
            {
                return false;
            }

            course.IsDeleted = true;
            _courseWriteRepo.Update(course);
            await _courseWriteRepo.SaveAsync();
            return true;
        }
    }
}
