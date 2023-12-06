using Domain.Repositories.Abstract;
using Domain.Repositories.Abstract.Store;

namespace ASPN.Domain {
    public class DataManager {
        public IArticleR Articles { get; set; }
        public IPageR Pages { get; set; }
        public ICommentR Comments { get; set; }
        public IItemR Items { get; set; }
        public IItemImageR ItemImages { get; set; }
        public DataManager(IArticleR articleR, IPageR pageR, ICommentR commentR, IItemR itemR, IItemImageR itemimageR) {
            this.Articles = articleR;
            this.Pages = pageR;
            this.ItemImages = itemimageR;
            this.Items = itemR;
            this.Comments = commentR;
        }
    }
}
