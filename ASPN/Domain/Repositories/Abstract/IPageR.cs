using ASPN.Domain.Entities;

namespace ASPN.Domain.Repositories.Abstract {
    public interface IPageR {
        public Page GetPage(Guid id);
        public IQueryable<Page> GetPages();
        public void SavePage(Page page);
        public void DeletePage(Guid id);
    }
}
