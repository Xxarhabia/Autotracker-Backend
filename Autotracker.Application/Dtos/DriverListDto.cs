namespace Autotracker.Application.Dtos
{
    public class DriverListDto
    {
        public int Id { get; set; }
        public string Document {  get; set; }
        public string FullName { get; set; }
        public string? VehiclePlate { get; set; }
    }
}
