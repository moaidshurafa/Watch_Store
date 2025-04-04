using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchStore.API.Models;
using WatchStore.API.Models.DTO;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository ordersRepository;
        private readonly IMapper mapper;

        public OrdersController(IOrdersRepository ordersRepository, IMapper mapper)
        {
            this.ordersRepository = ordersRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await ordersRepository.GetAllAsync();
            return Ok(mapper.Map<List<OrderDTO>>(orders));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var order = await ordersRepository.GetAsync(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<OrderDTO>(order));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddOrderRequest orderRequest)
        {
            var order = mapper.Map<Order>(orderRequest);
            await ordersRepository.AddAsync(order);
            return Ok(mapper.Map<OrderDTO>(order));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateOrderRequestDTO orderRequestDTO)
        {
            var existingOrder = await ordersRepository.GetAsync(x => x.Id == id);
            if (existingOrder == null)
            {
                return NotFound();
            }
            mapper.Map(orderRequestDTO, existingOrder);
            await ordersRepository.UpdateAsync(existingOrder);
            return Ok(mapper.Map<OrderDTO>(existingOrder));
        }
    }
}
