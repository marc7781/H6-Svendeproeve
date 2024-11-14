using FrontendModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        RatingController repo;
        public RatingController()
        {
            repo = new RatingController();
        }
        [HttpGet("{ratingId}")]
        public async Task<IActionResult> GetRatingAsync(int ratingId)
        {
            try
            {
                return Ok(await repo.GetRatingAsync(ratingId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRatingAsync()
        {
            try
            {
                return Ok(await repo.GetAllRatingAsync());
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateRatingAsync(Rating rating)
        {
            try
            {
                return Ok(await repo.CreateRatingAsync(rating));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
