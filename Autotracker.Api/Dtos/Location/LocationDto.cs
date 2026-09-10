namespace Autotracker.Api.Dtos.Location
{
    public record LocationDto(
        double Latitude,
        double Longitude,
        DateTime Timestamp
    );
}
