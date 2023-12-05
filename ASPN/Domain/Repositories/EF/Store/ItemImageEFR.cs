using ASPN.Domain.Repositories.Abstract.Store;

namespace ASPN.Domain.Repositories.EF.Store {
    public class ItemImageEFR:IItemImageR {
        private readonly AppDbContext context;

        public ItemImageEFR(AppDbContext context) {
            this.context=context;
        }

        public void AddImageToItem(Guid ItemId, string PathToImage) {
            throw new NotImplementedException();
        }

        public void DeleteImageFromItem(Guid ItemId, Guid ImageId) {
            throw new NotImplementedException();
        }

        public ICollection<string> GetImagesForItem(Guid ItemId) {
            throw new NotImplementedException();
        }

        public void UpdateImage(Guid ImageId, string PathToImage) {
            throw new NotImplementedException();
        }
    }
}
