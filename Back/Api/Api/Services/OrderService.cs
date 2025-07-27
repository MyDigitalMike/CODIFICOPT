using Api.Data.Repositories;
using Api.DTOs;

namespace Api.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<ClientOrderDto>> GetOrdersByCustomerAsync(int customerId)
        {
            return await _orderRepository.GetOrdersByCustomerAsync(customerId);
        }
        public async Task<int> AddNewOrderWithProductsAsync(OrderDto order)
        {
            return await _orderRepository.AddNewOrderWithProductsAsync(order);
        }
    }
}
