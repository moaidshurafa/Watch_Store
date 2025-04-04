using WatchStore.API.Models;

namespace WatchStore.API.Repositories.IRepository
{
    public interface ICustomerRepository : IRepository<Customer> 
    {
        Task<Customer> UpdateAsync(Customer customer);

    }
}
