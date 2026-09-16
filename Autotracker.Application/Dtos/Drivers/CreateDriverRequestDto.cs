namespace Autotracker.Application.Dtos.Drivers
{
    public class CreateDriverRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Document { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
    }
}
