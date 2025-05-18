using Microsoft.AspNetCore.Mvc;
using Question2.Models;
using Question2.Services.Interfaces;

namespace Question2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet("recent")]
        public async Task<ActionResult<List<OrderDetailDTO>>> GetRecentOrders()
        {
            try
            {
                var orderDetails = await _orderService.GetRecentOrderDetails();
                return Ok(orderDetails);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving recent orders");
                return StatusCode(500, "An error occurred while processing your request. Please try again later.");
            }
        }
    }
}
