using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        private readonly WatchStoreDbContext dbContext;

        public BrandRepository(WatchStoreDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Brand> UpdateAsync(Brand brand)
        {
            dbContext.Brands.Update(brand);
            await dbContext.SaveChangesAsync();
            return brand;
        }
    }
}
