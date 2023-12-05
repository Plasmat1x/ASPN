using System.ComponentModel.DataAnnotations;

namespace ASPN.Models {
    public class PageViewModel {
        [Required]
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Required]
        [Display(Name = "Code word")]
        public string CodeWord { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Text")]
        public string Text { get; set; }

        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Created at")]
        public DateTime CreatedAt { get; set; }

        public PageViewModel() { Id=new Guid().ToString(); }
    }
}
