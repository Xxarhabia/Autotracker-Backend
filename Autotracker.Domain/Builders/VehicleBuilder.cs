using Autotracker.Domain.Entities;

namespace Autotracker.Domain.Builders
{
    public class VehicleBuilder
    {
        private string _plate = string.Empty;
        private string _brand = string.Empty;
        private string _model = string.Empty;
        private string _year = string.Empty;

        private bool _engineOn = false;
        private bool _locked = false;
        private bool _inmobilized = false;

        private Location? _initialLocation;

        public VehicleBuilder WithPlate(string plate)
        {
            _plate = plate;
            return this;
        }

        public VehicleBuilder WithBrand(string brand)
        {
            _brand = brand;
            return this;
        }

        public VehicleBuilder WithModel(string model)
        {
            _model = model;
            return this;
        }

        public VehicleBuilder WithYear(string year)
        {
            _year = year;
            return this;
        }

        public VehicleBuilder WithInitialLocation(double latitude, double Longitude, DateTime timestamp)
        {
            _initialLocation = new Location(latitude, Longitude, timestamp);
            return this;
        }

        public VehicleBuilder WithEngineOn(bool engineOn)
        {
            _engineOn = engineOn;
            return this;
        }

        public VehicleBuilder WithLocked(bool locked)
        {
            _locked = locked;
            return this;
        }

        public VehicleBuilder WithInmovilized(bool inmovilized)
        {
            _inmobilized = inmovilized;
            return this;
        }

        public Vehicle build()
        {
            if (_initialLocation == null)
                throw new InvalidOperationException("El vehiculo debe tener una ubicacion inicial");

            return new Vehicle(
                _plate,
                _brand,
                _model,
                _year,
                _engineOn,
                _locked,
                _inmobilized,
                _initialLocation
            );
        }
    }
}
