using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASPN.Models
{
    public class UserRoleViewModel
    {
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool IsSelected { get; set; }
    }
}
