using EMS.Domain.Entities;


namespace EMS.Application.Features.UserFeatures.Queries
{
    public class LoginUserQuery
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
