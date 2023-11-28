using ASPN.Domain.Repositories.Abstract;

namespace ASPN.Domain
{
    public class DataManager
    {
        public IArticleR Articles { get; set; }
        public DataManager(IArticleR articleR)
        {
            this.Articles = articleR;
        }
    }
}
