using System;
using System.Collections.Generic;
using System.Text;

namespace Autotracker.Domain.Entities
{
    public class Location
    {
        public int Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public int VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public Location() { }

        public Location(int id, double latitude, double longitude, DateTime timestamp)
        {
            Id = id;
            Latitude = latitude;
            Longitude = longitude;
            Timestamp = timestamp;
        }

        public override string ToString()
        {
            return $"\n\tLatiud: {Latitude}" +
                $"\n\tLongitud: {Longitude}" +
                $"\n\tHora: {Timestamp}";
        }
    }
}
