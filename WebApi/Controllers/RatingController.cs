using FrontendModels;
using ApiRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        RatingRepository repo;
        public RatingController()
        {
            repo = new RatingRepository();
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
        [HttpGet("UsersRatings/{userid}")]
        public async Task<IActionResult> GetAllUsersRatingsAsync(int userId)
        {
            List<Rating> usersRatings = null;
            try
            {
               usersRatings = await repo.GetAllUsersRatingsAsync(userId);
            }
            catch
            {
                return BadRequest();
            }
            if(usersRatings != null)
            {
                return Ok(usersRatings);
            }
            return NotFound();
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
