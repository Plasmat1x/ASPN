namespace Domain.Repositories.Abstract.Store {
    public interface IItemImageR {
        public ICollection<string> GetImagesForItem(Guid ItemId);
        public void DeleteImageFromItem(Guid ItemId, Guid ImageId);
        public void SaveImageToItem(Guid ItemId, string PathToImage);


        public Task<ICollection<string>> GetImagesForItemAync(Guid ItemId, CancellationToken ct = default);
        public Task DeleteImageFromItemAsync(Guid ItemId, Guid ImageId, CancellationToken ct = default);
        public Task SaveImageToItemAsync(Guid ItemId, string PathToImage, CancellationToken ct = default);

    }
}
