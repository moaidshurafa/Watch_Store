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
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewRepository reviewRepository;
        private readonly IMapper mapper;

        public ReviewsController(IReviewRepository reviewRepository, IMapper mapper)
        {
            this.reviewRepository = reviewRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var reviews = await reviewRepository.GetAllAsync();
            return Ok(mapper.Map<List<ReviewDTO>>(reviews));
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddReviewRequestDTO reviewDTO)
        {
            var review = mapper.Map<Review>(reviewDTO);
            await reviewRepository.AddAsync(review);
            return Ok(mapper.Map<ReviewDTO>(review));
        }
    }
}
