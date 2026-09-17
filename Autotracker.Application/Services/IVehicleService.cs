using Autotracker.Application.Common;
using Autotracker.Application.Dtos.Locations;
using Autotracker.Application.Dtos.Vehicles;

namespace Autotracker.Application.Services
{
    public interface IVehicleService
    {
        public Task<ServiceResult> RegisterVehicleAsync(CreateVehicleDto vehicleDto);
        public Task<ServiceResult> ListVehiclesAsync();
        public Task<ServiceResult> SerchVehicleAsync(string plate);
        public Task<ServiceResult> LockVehicleAsync(string plate);
        public Task<ServiceResult> UnlockVehicleAsync(string plate);
        public Task<ServiceResult> StartVehicleAsync(string plate);
        public Task<ServiceResult> StopVehicleAsync(string plate);
        public Task<ServiceResult> UpdateVehicleLocationAsync(string plate, LocationDto newLocationDto);
    }
}
