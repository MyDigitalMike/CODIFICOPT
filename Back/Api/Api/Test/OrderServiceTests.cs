using Api.Data.Repositories;
using Api.DTOs;
using Api.Services;
using Moq;
using Xunit;

namespace Api.Test
{
    public class OrderServiceTests
    {
        [Fact]
        public async Task GetOrdersByCustomerAsync_ReturnsOrders()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.GetOrdersByCustomerAsync(1))
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

            var service = new OrderService(mockRepo.Object);

            // Act
            var result = await service.GetOrdersByCustomerAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result);
        }
        [Fact]
        public async Task AddNewOrderWithProducts_ShouldReturnOrderId()
        {
            // Arrange
            var mockRepo = new Mock<IOrderRepository>();
            mockRepo.Setup(repo => repo.AddNewOrderWithProductsAsync(It.IsAny<OrderDto>()))
                    .ReturnsAsync(1);

            var service = new OrderService(mockRepo.Object);

            // Act
            var result = await service.AddNewOrderWithProductsAsync(new OrderDto
            {
                EmpId = 1,
                ShipperId = 2,
                ShipName = "Test Ship",
                ShipAddress = "123 Test St",
                ShipCity = "Test City",
                OrderDate = DateTime.Now,
                RequiredDate = DateTime.Now.AddDays(7),
                OrderDetails = new List<OrderDetailDto>
            {
                new OrderDetailDto { ProductId = 1, UnitPrice = 10.5M, Qty = 2, Discount = 0 }
            }
            });

            // Assert
            Assert.Equal(1, result);
        }
    }
}
