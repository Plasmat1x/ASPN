using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class UserViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birth date")]
        public DateTime? Birthday { get; set; }

        [Required]
        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Roles")]
        public IEnumerable<string> Roles { get; set; }
    }
}
