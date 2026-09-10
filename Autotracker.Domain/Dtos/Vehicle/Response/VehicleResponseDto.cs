namespace Autotracker.Api.Dtos.Vehicle.Response
{
    public record VehicleResponseDto(bool Status, string Message, VehicleDto Vehicle);

    public record VehicleResponseListDto(bool Status, string Message, List<VehicleDto> Vehicles);


}
