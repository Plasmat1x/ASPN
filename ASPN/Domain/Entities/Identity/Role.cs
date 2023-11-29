using Microsoft.AspNetCore.Identity;

namespace ASPN.Domain.Entities.Identity
{
    public class Role : IdentityRole
    {
        public string? Description { get; set; }
    }
}
