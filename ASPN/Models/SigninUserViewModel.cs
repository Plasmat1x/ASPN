using System.ComponentModel.DataAnnotations;

namespace ASPN.Models {
    public class SigninUserViewModel {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [UIHint("Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }
    }
}
