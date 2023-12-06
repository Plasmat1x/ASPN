using Domain.Entities;
using Domain.Repositories.Abstract;

using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories.EF {
    public class CommentEFR: ICommentR {
        private readonly AppDbContext context;

        public CommentEFR(AppDbContext context) {
            this.context = context;
        }

        public async Task CreateCommentAsync(Comment comment, CancellationToken ct = default) {
            context.Entry(comment).State = EntityState.Added;
            await context.SaveChangesAsync(ct);
        }

        public async Task DeleteCommentAsync(Guid commentId, CancellationToken ct = default) {
            context.Comments.Remove(new Comment { Id = commentId });
            await context.SaveChangesAsync(ct);
        }

        public async Task<Comment> GetCommentAsync(Guid id, CancellationToken ct = default) {
            var data = await context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            return data;
        }

        public async Task<IQueryable<Comment>> GetCommentsAsync(Guid targetId, CancellationToken ct = default) {
            var data = context.Comments.Where(x => x.PageId == targetId);
            return data;
        }

        public async Task UpdadteCommentAsync(Comment comment, CancellationToken ct = default) {
            context.Comments.Update(comment);
            await context.SaveChangesAsync(ct);
        }
    }
}
