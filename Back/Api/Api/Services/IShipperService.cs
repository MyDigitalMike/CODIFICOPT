using Api.DTOs;

namespace Api.Services
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperDto>> GetAllShippersAsync();
    }
}
