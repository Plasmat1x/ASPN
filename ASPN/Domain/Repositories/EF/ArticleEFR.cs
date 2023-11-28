using ASPN.Domain.Entities;
using ASPN.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain.Repositories.EF
{
    public class ArticleEFR : IArticleR
    {
        private readonly AppDbContext context;

        public ArticleEFR(AppDbContext context)
        {
            this.context = context;
        }

        public void SaveArticle(Article article)
        {
            if (article.Id == default)
                context.Entry(article).State = EntityState.Added;
            else
                context.Entry(article).State = EntityState.Modified;

            context.SaveChanges();
        }

        public Article GetArticleByCodeWord(string CodeWord)
        {
            return context.Articles.FirstOrDefault(x => x.CodeWord == CodeWord);
        }

        public Article GetArticleById(Guid id)
        {
            return context.Articles.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Article> GetArticles()
        {
            return context.Articles;
        }

        public void DeleteArticle(Guid id)
        {
            context.Articles.Remove(new Article() { Id = id });
            context.SaveChanges();
        }




    }
}
