using WatchStore.API.Models;

namespace WatchStore.API.Repositories.IRepository
{
    public interface IOrdersRepository : IRepository<Order>
    {
        Task<Order> UpdateAsync(Order order);
    }
}
