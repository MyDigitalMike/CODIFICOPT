using Api.Data.Repositories;
using Api.DTOs;
using Api.Services;
using Moq;
using Xunit;

namespace Api.Test
{
    public class EmployeeServiceTests
    {
        [Fact]
        public async Task GetAllEmployees_ShouldReturnEmployeeList()
        {
            // Arrange
            var mockRepository = new Mock<IEmployeeRepository>();
            mockRepository.Setup(repo => repo.GetAllEmployeesAsync())
                .ReturnsAsync(new List<EmployeeDto>
                {
                new EmployeeDto { EmpId = 1, FullName = "John Doe" },
                new EmployeeDto { EmpId = 2, FullName = "Jane Smith" }
                });

            var service = new EmployeeService(mockRepository.Object);

            // Act
            var result = await service.GetAllEmployeesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("John Doe", result.First().FullName);
        }
    }
}
