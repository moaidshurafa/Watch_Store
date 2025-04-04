using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly WatchStoreDbContext dbContext;

        public CustomerRepository(WatchStoreDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Customer> UpdateAsync(Customer customer)
        {
            dbContext.Customers.Update(customer);
            await dbContext.SaveChangesAsync();
            return customer;
        }
    }
}
