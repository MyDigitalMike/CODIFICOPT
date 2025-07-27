using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        /// <summary>
        /// List orders by customer ID.
        /// </summary>
        [HttpGet("{customerId}/orders")]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
        public async Task<IActionResult> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            return Ok(orders);
        }
        /// <summary>
        /// Add new Order.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(IEnumerable<OrderDto>), 200)]
        public async Task<IActionResult> AddOrderWithProducts([FromBody] OrderDto order)
        {
            var newOrderId = await _orderService.AddNewOrderWithProductsAsync(order);
            if (newOrderId == -1)
            {
                return StatusCode(500, "Error creating the order.");
            }

            return Ok(new { NewOrderId = newOrderId });
        }
    }
}
