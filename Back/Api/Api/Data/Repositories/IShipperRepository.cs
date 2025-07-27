using Api.DTOs;

namespace Api.Data.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<ShipperDto>> GetAllShippersAsync();
    }
}
