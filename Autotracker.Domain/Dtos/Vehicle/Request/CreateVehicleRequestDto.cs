namespace Autotracker.Api.Dtos.Vehicle.Request
{
    public class CreateVehicleRequestDto
    {
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
    }
}
