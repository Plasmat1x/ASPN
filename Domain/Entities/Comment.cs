namespace Domain.Entities {
    public class Comment {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedAt { get; set; }

        public Guid PageId { get; set; }
    }
}
