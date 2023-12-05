using ASPN.Domain.Entities.Store;
using ASPN.Domain.Repositories.Abstract.Store;

namespace ASPN.Domain.Repositories.EF.Store {
    public class ItemEFR:IItemR {
        private readonly AppDbContext context;

        public ItemEFR(AppDbContext context) {
            this.context=context;
        }

        public void CreateItem(Item item) {
            context.Add<Item>(item);
            context.SaveChanges();
        }

        public void DeleteItem(Guid id) {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id) {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetItems() {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item) {
            throw new NotImplementedException();
        }
    }
}
