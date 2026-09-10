namespace Autotracker.Api.Dtos.Vehicle
{
    public record VehicleDto(
        int VehicleId,
        string Plate,
        string Brand,
        string Model,
        string Year
    );
}
