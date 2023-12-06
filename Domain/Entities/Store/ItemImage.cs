namespace Domain.Entities.Store {
    public class ItemImage {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public string ImagePath { get; set; }
    }
}
