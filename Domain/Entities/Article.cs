namespace ASPN.Domain.Entities {
    public class Article: EntityBase {
        public string CodeWord { get; set; }
        public override string Title { get; set; }
        public override string Text { get; set; }
    }
}
