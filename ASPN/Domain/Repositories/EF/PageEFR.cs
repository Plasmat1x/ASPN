using ASPN.Domain.Entities;
using ASPN.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain.Repositories.EF
{
    public class PageEFR : IPageR
    {
        private readonly AppDbContext context;
        public PageEFR(AppDbContext context) { this.context = context; }

        public Page GetPage(Guid id)
        {
            return context.Pages.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Page> GetPages()
        {
            return context.Pages;
        }

        public void DeletePage(Guid id)
        {
            context.Pages.Remove(new Page { Id = id });
            context.SaveChanges();
        }

        public void SavePage(Page page)
        {
            if (page.Id == default)
                context.Entry(page).State = EntityState.Added;
            else
                context.Entry(page).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
