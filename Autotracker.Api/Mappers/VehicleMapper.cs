using Autotracker.Application.Dtos.Locations;
using Autotracker.Application.Dtos.Vehicles;
using Autotracker.Domain.Entities;

namespace Autotracker.Api.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDto ToDto(Vehicle vehicle)
        {
            return new VehicleDto
            {
                Plate = vehicle.Plate,
                Brand = vehicle.Brand,
                Model = vehicle.Model,
                Year = vehicle.Year,
                EngineOn = vehicle.EngineOn,
                Locked = vehicle.Locked,
                Inmovilized = vehicle.Inmovilized,
                CurrentLocation = vehicle.CurrentLocation == null ? null : ToDto(vehicle.CurrentLocation)
            };
        }

        public static LocationDto ToDto(Location location)
        {
            return new LocationDto
            {
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Timestamp = location.Timestamp
            };
        }
    }
}
