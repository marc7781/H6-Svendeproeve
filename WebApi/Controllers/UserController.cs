using ApiRepository;
using FrontendModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserRepository repo;
        public UserController()
        {
            repo = new UserRepository();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserPasswrodAsync(string username)
        {
            try
            {
                return Ok(await repo.GetUserPasswordAsync(username));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserAsync(int userId)
        {
            try
            {
                return Ok(await repo.GetUserAsync(userId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUserAsync(User user)
        {
            try
            {
                return Ok(await repo.UpdateUserAsync(user));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(User user)
        {
            try
            {
                return Ok(await repo.CreateUserAsync(user));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
