using Api.Data.Context;
using Api.DTOs;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories
{
    public class ShipperRepository: IShipperRepository
    {
        private readonly ApplicationDbContext _context;
        public ShipperRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ShipperDto>> GetAllShippersAsync()
        {
            return await _context.Set<ShipperDto>()
                .FromSqlRaw("EXEC GetShippers")
                .ToListAsync();
        }

    }
}
