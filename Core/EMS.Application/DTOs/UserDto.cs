namespace EMS.Application.DTO
{
    namespace EMS.API.DTOs
    {
        public class RegisterUserDto
        {
            public string? Name { get; set; }
            public string? Surname { get; set; }
            public string? Phone { get; set; }
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? UserType { get; set; } // "Teacher" or "Student"
        }

        public class LoginUserDto
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

    }

}
