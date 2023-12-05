namespace ASPN.Domain.Entities {
    public class EntityBase {
        public Guid Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Description { get; set; }
        public virtual string Text { get; set; }
        public virtual string? Author { get; set; }
        public virtual string? ImagePath { get; set; }
        public DateTime CreatedAt { get; set; }
        protected EntityBase() => CreatedAt = DateTime.UtcNow;
    }
}
