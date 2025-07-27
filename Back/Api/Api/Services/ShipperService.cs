using Api.Data.Repositories;
using Api.DTOs;

namespace Api.Services
{
    public class ShipperService:IShipperService
    {
        private readonly IShipperRepository _shipperRepository;

        public ShipperService(IShipperRepository shipperRepository)
        {
            _shipperRepository = shipperRepository;
        }
        public async Task<IEnumerable<ShipperDto>> GetAllShippersAsync()
        {
            return await _shipperRepository.GetAllShippersAsync();
        }
    }
}
