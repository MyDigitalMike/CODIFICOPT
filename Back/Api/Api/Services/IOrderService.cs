using Api.DTOs;

namespace Api.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<ClientOrderDto>> GetOrdersByCustomerAsync(int customerId);
        Task<int> AddNewOrderWithProductsAsync(OrderDto order);
    }
}
