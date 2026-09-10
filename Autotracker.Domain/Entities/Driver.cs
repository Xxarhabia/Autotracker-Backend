using System;
using System.Collections.Generic;
using System.Text;

namespace Autotracker.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string Phone { get; private set; }
        public int? VehicleId { get; private set; }
        public Vehicle Vehicle { get; private set; }

        public Driver() { }

        public Driver(string name, string document, string phone, Vehicle vehicle = null)
        {
            Name = name;
            Document = document;
            Phone = phone;
            if (vehicle != null) AssignVehicle(vehicle);
        }

        public void AssignVehicle(Vehicle vehicle)
        {
            Vehicle = vehicle;
            VehicleId = vehicle.Id;
        }

        public void UnassignVehicle()
        {
            Vehicle = null;
            VehicleId = null;
        }

        public override string ToString()
        {
            return $"\n\tId: {Id}" +
                $"\n\tNombre: {Name}" +
                $"\n\tDocumento: {Document}" +
                $"\n\tTelefono: {Phone}" +
                $"\n\tVehiculo: {(Vehicle != null ? $"Placa: {Vehicle.Plate} - Marca: {Vehicle.Brand}" : "No hay vehiculo asignado")}";
        }
    }
}
