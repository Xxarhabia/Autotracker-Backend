namespace Autotracker.Application.Dtos.Vehicles
{
    public class CreateVehicleDto
    {
        public string Plate { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;
    }
}
