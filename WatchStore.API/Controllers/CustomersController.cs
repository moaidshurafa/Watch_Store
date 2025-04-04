using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Models.DTO;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly WatchStoreDbContext dbContext;
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomersController(WatchStoreDbContext dbContext, IMapper mapper, ICustomerRepository customerRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await customerRepository.GetAllAsync();
            return Ok(mapper.Map<List<CustomerDTO>>(customers));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var customer = await customerRepository.GetAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<CustomerDTO>(customer));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCustomerRequest customerRequest)
        {
            var customer = mapper.Map<Customer>(customerRequest);
            await customerRepository.AddAsync(customer);
            return Ok(mapper.Map<CustomerDTO>(customer));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCustomerRequestDTO customerRequestDTO)
        {
            var existingCustomer = await customerRepository.GetAsync(x => x.Id == id);
            if(existingCustomer == null)
            {
                return NotFound();
            }
            mapper.Map(customerRequestDTO, existingCustomer);
            await customerRepository.UpdateAsync(existingCustomer);
            return Ok(mapper.Map<CustomerDTO>(existingCustomer));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var customer = await customerRepository.GetAsync(x => x.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            await customerRepository.RemoveAsync(customer);
            return Ok(mapper.Map<CustomerDTO>(customer));
        }
    }
}
