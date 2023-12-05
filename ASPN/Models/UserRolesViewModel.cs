using System.ComponentModel.DataAnnotations;

namespace ASPN.Models {
    public class UserRolesViewModel {
        [Required]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "User")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Role")]
        public Dictionary<string, bool> RoleChecked { get; set; }
    }
}
