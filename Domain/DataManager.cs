using ASPN.Domain.Repositories.Abstract;

namespace ASPN.Domain {
    public class DataManager {
        public IArticleR Articles { get; set; }
        public IPageR Pages { get; set; }
        public DataManager(IArticleR articleR, IPageR pageR) {
            this.Articles = articleR;
            this.Pages = pageR;
        }
    }
}
