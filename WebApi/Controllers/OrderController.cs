using Microsoft.AspNetCore.Mvc;
using ApiRepository;
using FrontendModels;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderRepository repo { get; set; }
        public OrderController()
        {
            repo = new OrderRepository();
        }
        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOneOrderAsync(int orderId)
        {
            try
            {
                return Ok(await repo.GetOneOrderAsync(orderId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOrderAsync()
        {
            try
            {
                return Ok(await repo.GetAllOrdersAsync());
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("Customer/{ownerId}")]
        public async Task<IActionResult> GetOrdersFromOwnerIdAsync(int ownerId)
        {
            try
            {
                return Ok(await repo.GetAllOrdersFromOwnerId(ownerId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpGet("Driver/{driverId}")]
        public async Task<IActionResult> GetOrdersFromDriverIdAsync(int driverId)
        {
            try
            {
                return Ok(await repo.GetAllOrdersFromDriverId(driverId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync(Order order)
        {
            try
            {
                return Ok(await repo.UpdateOrderAsync(order));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderAsync(int orderId)
        {
            try
            {
                return Ok(await repo.DeleteOrderAsync(orderId));
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(Order order)
        {
            try
            {
                return Ok(await repo.CreateOrderAsync(order));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
