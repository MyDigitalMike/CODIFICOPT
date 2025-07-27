using Microsoft.AspNetCore.Mvc;
using Api.Services;
using Api.DTOs;
namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerPredictionController : ControllerBase
    {
        private readonly CustomerPredictionService _service;
        public CustomerPredictionController(CustomerPredictionService service)
        {
            _service = service;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CustomerPredictionDto>), 200)]
        public async Task<IActionResult> GetCustomerPredictions([FromQuery] string? customerName)
        {
            var predictions = await _service.GetCustomerPredictionsAsync(customerName);
            return Ok(predictions);
        }
    }
}
