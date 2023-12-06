using Domain.Entities;

namespace Domain.Repositories.Abstract {
    public interface IPageR {
        public Page GetPage(Guid id);
        public IQueryable<Page> GetPages();
        public void SavePage(Page page);
        public void DeletePage(Guid id);

        //=======async
        public Task<Page> GetPageAsync(Guid id, CancellationToken ct = default);
        public Task<IQueryable<Page>> GetPagesAsync(CancellationToken ct = default);
        public Task SavePageAsync(Page page, CancellationToken ct = default);
        public Task DeletePageAsync(Guid id, CancellationToken ct = default);
    }
}
