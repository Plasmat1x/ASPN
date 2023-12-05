using ASPN.Domain.Entities;
using ASPN.Domain.Repositories.Abstract;

using Microsoft.EntityFrameworkCore;

namespace ASPN.Domain.Repositories.EF {
    public class PageEFR:IPageR {
        private readonly AppDbContext context;
        public PageEFR(AppDbContext context) { this.context = context; }

        public Page GetPage(Guid id) {
            return context.Pages.FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<Page> GetPages() {
            return context.Pages;
        }

        public void DeletePage(Guid id) {
            context.Pages.Remove(new Page { Id = id });
            context.SaveChanges();
        }

        public void SavePage(Page page) {
            if(page.Id == default)
                context.Entry(page).State = EntityState.Added;
            else
                context.Entry(page).State = EntityState.Modified;

            context.SaveChanges();
        }

        public async Task<Page> GetPageAsync(Guid id, CancellationToken ct = default) {
            var data = await context.Pages.FirstOrDefaultAsync(x => x.Id == id, ct);
            return data;
        }

        public async Task<IQueryable<Page>> GetPagesAsync(CancellationToken ct = default) {
            var data = context.Pages;
            return data;
        }

        public async Task SavePageAsync(Page page, CancellationToken ct = default) {
            if(page.Id == default)
                context.Entry(page).State = EntityState.Added;
            else
                context.Entry(page).State = EntityState.Modified;

            await context.SaveChangesAsync(ct);
        }

        public async Task DeletePageAsync(Guid id, CancellationToken ct = default) {
            context.Pages.Remove(new Page { Id = id });
            await context.SaveChangesAsync(ct);
        }
    }
}
