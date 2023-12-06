namespace Domain.Entities {
    public class Page: EntityBase {
        public string CodeWord { get; set; }
        public override string Title { get; set; }
        public override string Text { get; set; }
    }
}
