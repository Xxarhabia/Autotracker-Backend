using Autotracker.Domain.Entities;

namespace Autotracker.Api.Dtos.Driver
{
    public record DriverDto(
        string name,
        string document,
        string phone,
        int? vehicleId
    );
}
