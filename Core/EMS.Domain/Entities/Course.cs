using EMS.Domain.Common;
using EMS.Domain.Entities;

namespace EMS.Domain.Entities
{
    public class Course : BaseEntity
    {
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public bool IsMandatory { get; set; }
        public int Credit { get; set; }
        public Guid TeacherId { get; set; }
        public Teacher? Teacher { get; set; } // Navigation property
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
