using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class SignupUserViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [UIHint("Password")]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
