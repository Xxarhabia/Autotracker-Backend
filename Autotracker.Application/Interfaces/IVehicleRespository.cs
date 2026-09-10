using Autotracker.Domain.Entities;

namespace Autotracker.Application.Interfaces
{
    public interface IVehicleRespository
    {
        Task<Vehicle?> GetByPlateAsync(string plate);
        Task<List<Vehicle>> GetAllAsync();
        Task AddAsync(Vehicle vehicle);
        Task UpdateAsync(Vehicle vehicle);
        Task<bool> ExistsByPlateAsync(string plate);
    }
}
