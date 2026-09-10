using Autotracker.Api.Dtos.Location;
using Autotracker.Api.Dtos.Vehicle;
using Autotracker.Domain.Entities;

namespace Autotracker.Api.Mappers
{
    public static class VehicleMapper
    {
        public static VehicleDto ToDto(Vehicle vehicle)
        {
            return new VehicleDto(
                vehicle.Plate,
                vehicle.Brand,
                vehicle.Model,
                vehicle.Year,
                vehicle.EngineOn,
                vehicle.Locked,
                vehicle.Inmovilized,
                vehicle.CurrentLocation == null ? null : ToDto(vehicle.CurrentLocation)
            );
        }

        public static LocationDto ToDto(Location location)
        {
            return new LocationDto(
                location.Latitude,
                location.Longitude,
                location.Timestamp
            );
        }
    }
}
