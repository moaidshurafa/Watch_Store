using WatchStore.API.Models;

namespace WatchStore.API.Repositories.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        Task<Brand> UpdateAsync(Brand brand);
    }
}
