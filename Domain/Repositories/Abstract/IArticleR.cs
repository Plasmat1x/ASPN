using Domain.Entities;

namespace Domain.Repositories.Abstract {
    public interface IArticleR {

        //Read
        public IQueryable<Article> GetArticles();
        public Article GetArticleById(Guid id);
        public Article GetArticleByCodeWord(string CodeWord);

        // Create/Update
        public void SaveArticle(Article article);

        //Delete
        public void DeleteArticle(Guid id);


        //======async=======
        //Read
        public Task<IQueryable<Article>> GetArticlesAsync(CancellationToken ct = default);
        public Task<Article> GetArticleByIdAsync(Guid id, CancellationToken ct = default);
        public Task<Article> GetArticleByCodeWordAsync(string CodeWord, CancellationToken ct = default);

        // Create/Update
        public Task SaveArticleAsync(Article article, CancellationToken ct = default);

        //Delete
        public Task DeleteArticleAsync(Guid id, CancellationToken ct = default);

    }
}
