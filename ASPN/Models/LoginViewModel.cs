using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "RemberMe")]
        public bool RememberMe { get; set; }

    }
}
