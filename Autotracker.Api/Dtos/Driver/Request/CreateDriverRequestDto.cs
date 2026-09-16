namespace Autotracker.Api.Dtos.Driver.Request
{
    public record CreateDriverRequestDto(
        string Name,
        string Document,
        string Phone
    );
}
