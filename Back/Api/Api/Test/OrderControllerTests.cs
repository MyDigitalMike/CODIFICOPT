using Api.Controllers;
using Api.DTOs;
using Api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Test
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task GetOrdersByCustomer_ReturnsOk()
        {
            // Arrange
            var mockService = new Mock<IOrderService>();
            mockService.Setup(service => service.GetOrdersByCustomerAsync(1))
                       .ReturnsAsync(new List<ClientOrderDto>
                       {
                       new ClientOrderDto
                       {
                           OrderId = 1,
                           RequiredDate = DateTime.Now.AddDays(5),
                           ShippedDate = DateTime.Now,
                           ShipName = "Test Ship",
                           ShipAddress = "123 Test St",
                           ShipCity = "Test City"
                       }
                       });

            var controller = new OrderController(mockService.Object);

            // Act
            var result = await controller.GetOrdersByCustomer(1) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
