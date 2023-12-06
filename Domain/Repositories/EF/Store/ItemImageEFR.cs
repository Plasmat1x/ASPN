using Domain.Repositories.Abstract.Store;

namespace Domain.Repositories.EF.Store {
    public class ItemImageEFR: IItemImageR {
        private readonly AppDbContext context;

        public ItemImageEFR(AppDbContext context) {
            this.context = context;
        }

        public void SaveImageToItem(Guid ItemId, string PathToImage) {
            throw new NotImplementedException();
        }

        public void DeleteImageFromItem(Guid ItemId, Guid ImageId) {
            throw new NotImplementedException();
        }

        public ICollection<string> GetImagesForItem(Guid ItemId) {
            throw new NotImplementedException();
        }

        public Task<ICollection<string>> GetImagesForItemAync(Guid ItemId, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public Task DeleteImageFromItemAsync(Guid ItemId, Guid ImageId, CancellationToken ct = default) {
            throw new NotImplementedException();
        }

        public Task SaveImageToItemAsync(Guid ItemId, string PathToImage, CancellationToken ct = default) {
            throw new NotImplementedException();
        }
    }
}
