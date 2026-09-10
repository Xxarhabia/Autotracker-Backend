namespace Autotracker.Domain.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public bool EngineOn { get; private set; }
        public bool Locked { get; private set; }
        public bool Inmovilized { get; private set; }
        public List<Location> LocationHistory { get; private set; } = new();
        public Location? CurrentLocation => LocationHistory
            .OrderByDescending(l => l.Timestamp)
            .FirstOrDefault();

        public Vehicle() { }
        public Vehicle(
            string plate,
            string brand,
            string model,
            string year,
            bool engineOn,
            bool locked,
            bool inmovilized,
            Location initialLocation)
        {
            Plate = plate;
            Brand = brand;
            Model = model;
            Year = year;
            EngineOn = engineOn;
            Locked = locked;
            Inmovilized = inmovilized;
            LocationHistory.Add(initialLocation);
        }

        public void UpdateLocation(Location location)
        {
            LocationHistory.Add(location);
        }

        public string StartEngine()
        {
            if (Inmovilized)
                return "El vehiculo se encuentra inmovilizado";

            if (EngineOn)
                return "El vehiculo ya se encuentra encendido";

            EngineOn = true;
            return "Motor Encendido";
        }

        public string StopEngine()
        {
            if (!EngineOn)
                return "El vehiculo ya se encuentra apagado";

            EngineOn = false;
            return "Motor Apagado";
        }

        public string Lock()
        {
            if (EngineOn)
                return "El vehiculo no se puede bloquear. Motor encendido";

            if (Locked)
                return "El vehiculo ya se encuentra bloqueado";

            Locked = true;
            return "Vehiculo bloqueado";
        }

        public string Unlock()
        {
            if (!Locked)
                return "El vehiculo ya se encuentra desbloqueado";

            Locked = false;
            return "Vehiculo desbloqueado";
        }

        public override string ToString()
        {
            return $"Datos del Vehiculo: " +
                $"\n\tPlaca: {Plate}, " +
                $"\n\tMarca: {Brand}, " +
                $"\n\tModelo: {Model}, " +
                $"\n\tAño: {Year}, " +
                $"\n\tEncendido: {EngineOn}" +
                $"\n\tBloqueado: {Locked}" +
                $"\n\tInmovilizado: {Inmovilized}" +
                $"\n\tUbicacion: {CurrentLocation}";
        }
    }
}

