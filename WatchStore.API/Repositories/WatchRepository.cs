using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Repositories
{
    public class WatchRepository : Repository<Watch>, IWatchRepository
    {
        private readonly WatchStoreDbContext dbContext;

        public WatchRepository(WatchStoreDbContext dbContext): base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Watch> UpdateAsync(Watch watch)
        {
            dbContext.Watches.Update(watch);
            await dbContext.SaveChangesAsync();
            return watch;
        }
    }
}
