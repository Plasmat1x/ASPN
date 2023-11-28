using ASPN.Domain.Entities;

namespace ASPN.Domain.Repositories.Abstract
{
    public interface IArticleR
    {

        //Read
        public IQueryable<Article> GetArticles();
        public Article GetArticleById(Guid id);
        public Article GetArticleByCodeWord(string CodeWord);

        // Create/Update
        public void SaveArticle(Article article);

        //Delete
        public void DeleteArticle(Guid id);

    }
}
