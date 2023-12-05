using System.ComponentModel.DataAnnotations;

namespace ASPN.Models {
    public class EditUserViewModel {


        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Firstname")]
        public string FirstName { get; set; }

        [Display(Name = "Lastname")]
        public string LastName { get; set; }

        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }
    }
}
