using Microsoft.AspNetCore.Identity;

namespace ASPN.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
