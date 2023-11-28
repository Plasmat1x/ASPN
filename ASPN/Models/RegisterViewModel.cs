using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Password not match")]
        [UIHint("password")]
        [Display(Name = "Password confirm")]
        public string PasswordConfirm { get; set; }
    }
}
