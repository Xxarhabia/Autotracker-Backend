namespace Autotracker.Api.Dtos.Vehicle.Request
{
    public record CreateVehicleDto(
        string Plate,
        string Brand,
        string Model,
        int Year
    );
}
