namespace Autotracker.Api.Dtos.Driver.Response
{
    public record DriverResponseDto(bool Status, string Message, DriverDto Driver);

    public record DriverResponseLIistDto(bool Status, string Message, List<DriverDto> Drivers);
}
