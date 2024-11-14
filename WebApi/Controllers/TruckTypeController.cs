using ApiRepository;
using FrontendModels;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruckTypeController : ControllerBase
    {
        TruckTypeRepository repo;
        public TruckTypeController()
        {
            repo = new TruckTypeRepository();
        }
        [HttpGet("{trucktypeId}")]
        public async Task<IActionResult> GetTruckTypeAsync(int trucktypeId)
        {
            try
            {
                return Ok(await repo.GetTruckTypeAsync(trucktypeId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllTruckTypesAsync()
        {
            try
            {
                return Ok(await repo.GetAllTruckTypesAsync());
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
