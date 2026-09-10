using Autotracker.Application.Common;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services
{
    public interface IVehicleService
    {
        public Task<ServiceResult> RegisterVehicleAsync(Vehicle vehicle);
        public Task<ServiceResult> ListVehiclesAsync();
        public Task<ServiceResult> SerchVehicleAsync(string plate);
    }
}
