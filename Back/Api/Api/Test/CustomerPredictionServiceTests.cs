using System.Collections.Generic;
using System.Threading.Tasks;
using Moq;
using Api.Data.Repositories;
using Api.Data.UnitOfWork;
using Api.DTOs;
using Api.Services;
using Xunit;
namespace Api.Test
{
    public class CustomerPredictionServiceTests
    {
        [Fact]
        public async Task GetCustomerPredictionsAsync_WithFilter_ReturnsFilteredPredictions()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerPredictionRepository>();
            var customerNameFilter = "Test Customer";

            mockRepo.Setup(repo => repo.GetCustomerPredictionsAsync(customerNameFilter))
                    .ReturnsAsync(new List<CustomerPredictionDto>
                    {
                    new CustomerPredictionDto
                    {
                        CustomerName = "Test Customer",
                        LastOrderDate = DateTime.Now.AddDays(-10),
                        NextPredictedOrder = DateTime.Now.AddDays(20)
                    }
                    });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CustomerPredictions).Returns(mockRepo.Object);

            var service = new CustomerPredictionService(mockUnitOfWork.Object);

            // Act
            var result = await service.GetCustomerPredictionsAsync(customerNameFilter);

            // Assert
            Assert.NotNull(result);
            Assert.Single(result); // Ensure only one result is returned
            Assert.Equal("Test Customer", result.First().CustomerName); // Validate the filtered result
        }

        [Fact]
        public async Task GetCustomerPredictionsAsync_WithNullFilter_ReturnsAllPredictions()
        {
            // Arrange
            var mockRepo = new Mock<ICustomerPredictionRepository>();

            mockRepo.Setup(repo => repo.GetCustomerPredictionsAsync(null))
                    .ReturnsAsync(new List<CustomerPredictionDto>
                    {
                new CustomerPredictionDto
                {
                    CustomerName = "Test Customer 1",
                    LastOrderDate = DateTime.Now.AddDays(-10),
                    NextPredictedOrder = DateTime.Now.AddDays(20)
                },
                new CustomerPredictionDto
                {
                    CustomerName = "Test Customer 2",
                    LastOrderDate = DateTime.Now.AddDays(-15),
                    NextPredictedOrder = DateTime.Now.AddDays(25)
                }
                    });

            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.Setup(u => u.CustomerPredictions).Returns(mockRepo.Object);

            var service = new CustomerPredictionService(mockUnitOfWork.Object);

            // Act
            var result = await service.GetCustomerPredictionsAsync(null);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count()); // Verificar que devuelve todos los registros
            Assert.Contains(result, r => r.CustomerName == "Test Customer 1");
            Assert.Contains(result, r => r.CustomerName == "Test Customer 2");
        }
    }
}
