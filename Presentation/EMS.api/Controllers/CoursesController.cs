using EMS.API.DTOs;
using EMS.Domain.Entities;
using EMS.Application.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EMS.Application.Repositories;

namespace EMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Teacher")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseReadRepository _courseReadRepo;
        private readonly ICourseWriteRepository _courseWriteRepo;

        public CoursesController(ICourseReadRepository courseReadRepo, ICourseWriteRepository courseWriteRepo)
        {
            _courseReadRepo = courseReadRepo;
            _courseWriteRepo = courseWriteRepo;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> CreateCourse(CreateCourseDto createCourseDto)
        {
            if (createCourseDto.Credit > 6)
            {
                return BadRequest("Credit value cannot exceed 6.");
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

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (course == null)
            {
                return NotFound();
            }

            return Ok(course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id, UpdateCourseDto updateCourseDto)
        {
            var existingCourse = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (existingCourse == null)
            {
                return NotFound();
            }

            if (updateCourseDto.Credit > 6)
            {
                return BadRequest("Credit value cannot exceed 6.");
            }

            existingCourse.Name = updateCourseDto.Name;
            existingCourse.Explanation = updateCourseDto.Explanation;
            existingCourse.IsMandatory = updateCourseDto.IsMandatory;
            existingCourse.Credit = updateCourseDto.Credit;
            existingCourse.TeacherId = updateCourseDto.TeacherId;

            _courseWriteRepo.Update(existingCourse);
            await _courseWriteRepo.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _courseReadRepo.GetByIdAsync(id.ToString());
            if (course == null)
            {
                return NotFound();
            }

            _courseWriteRepo.Delete(course);
            await _courseWriteRepo.SaveAsync();

            return NoContent();
        }
    }
}
