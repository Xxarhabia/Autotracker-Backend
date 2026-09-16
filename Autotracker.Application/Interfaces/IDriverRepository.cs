using Autotracker.Application.Dtos.Drivers;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<DriverListDto?> GetByDocumentAsync(string document);
        Task<bool> ExistByDocumentAsync(string document);
        Task<List<DriverListDto>> GetAllAsync();
        Task AddAsync(Driver driver);
    }
}
