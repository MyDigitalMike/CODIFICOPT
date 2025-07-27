using Api.DTOs;
using Api.Models;

namespace Api.Data.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
    }
}
