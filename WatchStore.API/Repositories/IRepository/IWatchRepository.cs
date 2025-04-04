using WatchStore.API.Models;

namespace WatchStore.API.Repositories.IRepository
{
    public interface IWatchRepository : IRepository<Watch>
    {
        Task<Watch> UpdateAsync(Watch watch);
    }
}
