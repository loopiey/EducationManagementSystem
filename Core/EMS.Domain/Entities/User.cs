using EMS.Domain.Common;

namespace EMS.Domain.Entities
{
    public class User : EntityBase, IEntityBase
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public UserType UserType { get; set; }
    }

    public enum UserType
    {
        Teacher,
        Student
    }
}
