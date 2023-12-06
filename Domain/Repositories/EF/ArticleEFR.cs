using Domain.Entities;
using Domain.Repositories.Abstract;

using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.EF {
    public class ArticleEFR: IArticleR {
        private readonly AppDbContext context;

        public ArticleEFR(AppDbContext context) {
            this.context = context;
        }

        public void SaveArticle(Article article) {
            if(article.Id == default)
                context.Entry(article).State = EntityState.Added;
            else
                context.Entry(article).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Article GetArticleByCodeWord(string CodeWord) {
            return context.Articles.FirstOrDefault(x => x.CodeWord == CodeWord);
        }

        public Article GetArticleById(Guid id) {
            return context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Article> GetArticles() {
            return context.Articles;
        }

        public void DeleteArticle(Guid id) {
            context.Articles.Remove(new Article() { Id = id });
            context.SaveChanges();
        }

        public async Task<IQueryable<Article>> GetArticlesAsync(CancellationToken ct) {
            var data = context.Articles;
            return data;
        }

        public async Task<Article> GetArticleByIdAsync(Guid id, CancellationToken ct) {
            var data = await context.Articles.FirstOrDefaultAsync(x => x.Id == id, ct);
            return data;
        }

        public async Task<Article> GetArticleByCodeWordAsync(string CodeWord, CancellationToken ct) {
            var data = await context.Articles.FirstOrDefaultAsync(x => x.CodeWord == CodeWord, ct);
            return data;
        }

        public async Task SaveArticleAsync(Article article, CancellationToken ct) {
            if(article.Id == default)
                context.Entry(article).State = EntityState.Added;
            else
                context.Entry(article).State = EntityState.Modified;

            await context.SaveChangesAsync(ct);
        }

        public async Task DeleteArticleAsync(Guid id, CancellationToken ct) {
            context.Articles.Remove(new Article() { Id = id });
            await context.SaveChangesAsync(ct);
        }
    }
}
