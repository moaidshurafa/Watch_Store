using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Repositories
{
    public class OrdersRepository : Repository<Order> ,IOrdersRepository
    {
        private readonly WatchStoreDbContext dbContext;

        public OrdersRepository(WatchStoreDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Order> UpdateAsync(Order order)
        {
            dbContext.Orders.Update(order);
            await dbContext.SaveChangesAsync();
            return order;
        }
    }
}
