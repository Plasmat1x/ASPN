namespace ASPN.Domain.Repositories.Abstract.Store {
    public interface IItemImageR {
        public ICollection<string> GetImagesForItem(Guid ItemId);
        public void DeleteImageFromItem(Guid ItemId, Guid ImageId);
        public void AddImageToItem(Guid ItemId, string PathToImage);
        public void UpdateImage(Guid ImageId, string PathToImage);

    }
}
