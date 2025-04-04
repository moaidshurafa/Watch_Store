using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Repositories
{
    public class ReviewRepository : Repository<Review>, IReviewRepository
    {
        private readonly WatchStoreDbContext dbContext;

        public ReviewRepository(WatchStoreDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Review> UpdateAsync(Review review)
        {
            dbContext.Reviews.Update(review);
            await dbContext.SaveChangesAsync();
            return review;

        }
    }
}
