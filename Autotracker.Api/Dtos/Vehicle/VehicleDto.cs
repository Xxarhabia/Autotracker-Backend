using Autotracker.Api.Dtos.Location;

namespace Autotracker.Api.Dtos.Vehicle
{
    public record VehicleDto(
        string Plate,
        string Brand,
        string Model,
        string Year,
        bool EngineOn,
        bool Locked,
        bool Inmovilized,
        LocationDto? CurrentLocation
    );
}
