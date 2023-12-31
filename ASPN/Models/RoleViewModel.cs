﻿using System.ComponentModel.DataAnnotations;

namespace ASPN.Models {
    public class RoleViewModel {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
