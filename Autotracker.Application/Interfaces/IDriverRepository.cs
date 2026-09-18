using Autotracker.Application.Dtos.Drivers;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver?> GetDriverByDocumentAsync(string document);
        Task<DriverListDto?> GetByDocumentAsync(string document);
        Task<bool> ExistByDocumentAsync(string document);
        Task<List<DriverListDto>> GetAllAsync();
        Task AddAsync(Driver driver);
        Task UpdateAsync(Driver driver);
        Task<bool> IsVehicleAssignedToAnotherDriverAsync(int vehicleId, int driverId);
    }
}
