using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class EditUserViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password not match")]
        [UIHint("password")]
        [Display(Name = "Password confirm")]
        public string PasswordConfirm { get; set; }

        [Display(Name = "Role")]
        public string Role { get; set; }

        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; }

    }
}
