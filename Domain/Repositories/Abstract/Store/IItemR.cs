using Domain.Entities.Store;

namespace Domain.Repositories.Abstract.Store {
    public interface IItemR {
        public ICollection<Item> GetItems();
        public Item GetItem(Guid id);
        public void DeleteItem(Guid id);
        public void UpdateItem(Item item);
        public void CreateItem(Item item);

        public Task<ICollection<string>> GetImagesForItemAsync(Guid ItemId, CancellationToken ct = default);
        public Task DeleteImageFromItemAsync(Guid ItemId, Guid ImageId, CancellationToken ct = default);
        public Task AddImageToItemAsync(Guid ItemId, string PathToImage, CancellationToken ct = default);
        public Task UpdateImageAsync(Guid ImageId, string PathToImage, CancellationToken ct = default);

    }
}
