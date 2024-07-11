using EMS.Domain.Common;

namespace EMS.Domain.Entities
{
    public class Course : EntityBase, IEntityBase
    {
        public string? Name { get; set; }
        public string? Explanation { get; set; }
        public bool IsMandatory { get; set; }
        public int Credit { get; set; }
        public int TeacherId { get; set; }
        public User? Teacher { get; set; }
    }
}
