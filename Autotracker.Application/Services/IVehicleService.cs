using Autotracker.Api.Dtos;
using Autotracker.Application.Common;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services
{
    public interface IVehicleService
    {
        public ServiceResult RegisterVehicle(Vehicle vehicle);
        public ServiceResult ListVehicles();
        public ServiceResult SerchVehicle(string plate);
    }
}
