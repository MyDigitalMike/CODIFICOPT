using Api.Data.UnitOfWork;
using Api.DTOs;

namespace Api.Services
{
    public class CustomerPredictionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerPredictionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CustomerPredictionDto>> GetCustomerPredictionsAsync(string? customerName = null)
        {
            return await _unitOfWork.CustomerPredictions.GetCustomerPredictionsAsync(customerName);
        }
    }
}
