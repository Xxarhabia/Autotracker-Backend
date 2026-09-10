namespace Autotracker.Api.Dtos.Location
{
    public record LocationDto(
        int LocationId,
        double Latitude,
        double Longitude,
        DateTime Timestamp,
        int VehicleId
    );
}
