using Microsoft.AspNetCore.Identity;

namespace Domain.Entities.Identity {
    public class Role: IdentityRole {
        public string? Description { get; set; }
    }
}
