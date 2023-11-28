using System.ComponentModel.DataAnnotations;

namespace ASPN.Domain.Entities
{
    public class Article : EntityBase
    {
        [Required]
        public string CodeWord { get; set; }
        public override string Title { get; set; }
        public override string Text { get; set; }
    }
}
