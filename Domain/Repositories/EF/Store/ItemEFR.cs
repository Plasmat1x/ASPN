using Domain.Entities.Store;
using Domain.Repositories.Abstract.Store;

namespace Domain.Repositories.EF.Store {
    public class ItemEFR: IItemR {
        private readonly AppDbContext context;

        public ItemEFR(AppDbContext context) {
            this.context = context;
        }

        public Task AddImageToItemAsync(Guid ItemId, string PathToImage, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public void CreateItem(Item item) {
            context.Add<Item>(item);
            context.SaveChanges();
        }

        public Task DeleteImageFromItemAsync(Guid ItemId, Guid ImageId, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public void DeleteItem(Guid id) {
            throw new NotImplementedException();
        }

        public Task<ICollection<string>> GetImagesForItemAsync(Guid ItemId, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public Item GetItem(Guid id) {
            throw new NotImplementedException();
        }

        public ICollection<Item> GetItems() {
            throw new NotImplementedException();
        }

        public Task UpdateImageAsync(Guid ImageId, string PathToImage, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public void UpdateItem(Item item) {
            throw new NotImplementedException();
        }
    }
}
