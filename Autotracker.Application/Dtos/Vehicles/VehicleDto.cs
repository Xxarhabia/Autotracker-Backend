
using Autotracker.Application.Dtos.Locations;

namespace Autotracker.Application.Dtos.Vehicles
{
    public class VehicleDto
    {
        public string Plate {  get; set; } = string.Empty;
        public string Brand {  get; set; } = string.Empty;
        public string Model {  get; set; } = string.Empty;
        public string Year {  get; set; } = string.Empty;
        public bool EngineOn { get; set; }
        public bool Locked { get; set; }
        public bool Inmovilized { get; set; }
        public LocationDto? CurrentLocation { get; set; }
    }
}
