using ASPN.Domain.Entities.Store;

namespace ASPN.Domain.Repositories.Abstract.Store {
    public interface IItemR {
        public ICollection<Item> GetItems();
        public Item GetItem(Guid id);
        public void DeleteItem(Guid id);
        public void UpdateItem(Item item);
        public void CreateItem(Item item);

    }
}
