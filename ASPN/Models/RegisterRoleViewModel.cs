using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class RegisterRoleViewModel
    {
        [Required]
        [Display(Name = "Role name")]
        public string RoleName { get; set; }
    }
}
