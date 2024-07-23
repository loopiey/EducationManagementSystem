using EMS.Domain.Common;

namespace EMS.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; } // Teacher or Student
    }
}
