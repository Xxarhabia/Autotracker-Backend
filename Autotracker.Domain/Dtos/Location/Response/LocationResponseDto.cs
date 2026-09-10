namespace Autotracker.Api.Dtos.Location.Response
{
    public record LocationResponseDto(bool Status, string Message, LocationDto Location);

    public record LocationResponseListDto(bool Status, string Message, List<LocationDto> Locations);
}
