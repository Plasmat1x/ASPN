using Domain.Entities;

namespace Domain.Repositories.Abstract {
    public interface ICommentR {
        public Task<IQueryable<Comment>> GetCommentsAsync(Guid targetId, CancellationToken ct = default);
        public Task<Comment> GetCommentAsync(Guid id, CancellationToken ct = default);
        public Task CreateCommentAsync(Comment comment, CancellationToken ct = default);
        public Task UpdadteCommentAsync(Comment comment, CancellationToken ct = default);
        public Task DeleteCommentAsync(Guid id, CancellationToken ct = default);

    }
}
