using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchStore.API.Data;
using WatchStore.API.Models;
using WatchStore.API.Models.DTO;
using WatchStore.API.Repositories.IRepository;

namespace WatchStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchesController : ControllerBase
    {
        private readonly WatchStoreDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IWatchRepository watchRepository;

        public WatchesController(WatchStoreDbContext dbContext, IMapper mapper, IWatchRepository watchRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.watchRepository = watchRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var watches = await watchRepository.GetAllAsync();
            var watchesDto = mapper.Map<List<WatchDTO>>(watches);
            return Ok(watchesDto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var watch = await watchRepository.GetAsync(x => x.Id == id);
            if (watch == null)
            {
                return NotFound();
            }
            var watchDto = mapper.Map<WatchDTO>(watch);
            return Ok(watchDto);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWatchRequestDTO watchRequestDTO)
        {
            var watch = mapper.Map<Watch>(watchRequestDTO);
            await watchRepository.AddAsync(watch);
            return Ok(mapper.Map<WatchDTO>(watch));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWatchRequestDTO watchRequestDTO)
        {
            var existingWatch = await watchRepository.GetAsync(x => x.Id == id);
            if (existingWatch == null)
            {
                return NotFound();
            }
            mapper.Map(watchRequestDTO, existingWatch);

            await watchRepository.UpdateAsync(existingWatch);

            return Ok(mapper.Map<WatchDTO>(existingWatch));

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var watch = await watchRepository.GetAsync(x => x.Id == id);
            if (watch == null)
            {
                return NotFound();
            }
            await watchRepository.RemoveAsync(watch);
            return Ok(mapper.Map<WatchDTO>(watch));
        }
    }
}
