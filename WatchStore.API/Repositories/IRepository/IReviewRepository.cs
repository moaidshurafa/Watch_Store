using WatchStore.API.Models;

namespace WatchStore.API.Repositories.IRepository
{
    public interface IReviewRepository : IRepository<Review>
    {
        Task<Review> UpdateAsync(Review review);
    }
}
