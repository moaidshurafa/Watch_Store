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
    public class BrandsController : ControllerBase
    {
        private readonly WatchStoreDbContext dbContext;
        private readonly IMapper mapper;
        private readonly IBrandRepository brandRepository;

        public BrandsController(WatchStoreDbContext dbContext, IMapper mapper, IBrandRepository brandRepository)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var brands = await brandRepository.GetAllAsync();
            return Ok(mapper.Map<List<BrandsDTO>>(brands));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var brand = await brandRepository.GetAsync(x => x.Id == id);
            if (brand == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<BrandsDTO>(brand));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddBrandRequest brandRequest)
        {
            var brand = mapper.Map<Brand>(brandRequest);
            await brandRepository.AddAsync(brand);
            return Ok(mapper.Map<BrandsDTO>(brand));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateBrandRequest brandRequest)
        {
            var existingBrand = await brandRepository.GetAsync(x => x.Id == id);
            if (existingBrand == null)
            {
                return NotFound();
            }

            mapper.Map(brandRequest, existingBrand);


            await brandRepository.UpdateAsync(existingBrand);
            return Ok(mapper.Map<BrandsDTO>(existingBrand));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var Brand = await brandRepository.GetAsync(x => x.Id == id);
            if (Brand == null)
            {
                return NotFound();
            }
            await brandRepository.RemoveAsync(Brand);
            return Ok(mapper.Map<BrandsDTO>(Brand));
        }
    }
}
