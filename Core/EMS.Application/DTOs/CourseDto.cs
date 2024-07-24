namespace EMS.API.DTOs
{
    public class CreateCourseDto
    {
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public bool IsMandatory { get; set; }
        public int Credit { get; set; }
        public Guid TeacherId { get; set; }
    }

    public class UpdateCourseDto
    {
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public bool IsMandatory { get; set; }
        public int Credit { get; set; }
        public Guid TeacherId { get; set; }
    }
}
