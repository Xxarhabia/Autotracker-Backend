using Autotracker.Application.Common;
using Autotracker.Application.Interfaces;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services.Impl
{
    public class VehicleServiceImpl : IVehicleService
    {
        private readonly IVehicleRespository _respository;

        public VehicleServiceImpl(IVehicleRespository respository)
        {
            _respository = respository;
        }

        public ServiceResult RegisterVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                return new ServiceResult(false, "Error al registrar el vehiculo");

            if (_respository.ExistsByPlate(vehicle.Plate))
                return new ServiceResult(false, "Ya existe un vehiculo con esta placa");

            _respository.Add(vehicle);
            return new ServiceResult(true, "Vehiculo registrado con exito", vehicle);
        }

        public ServiceResult ListVehicles()
        {
            List<Vehicle> vehicles = _respository.GetAll();

            if (vehicles.Count() == 0) 
                return new ServiceResult(true, "No hay vehiculos registrados");

            return new ServiceResult(true, "Listado de vehiculos", vehicles);
        }

        public ServiceResult SerchVehicle(string plate)
        {
            Vehicle? vehicle = _respository.GetByPlate(plate);

            if (vehicle == null)
                return new ServiceResult(false, "El vehiculo no existe");

            return new ServiceResult(true, "Vehiculo encontrado", vehicle);
        }
    }
}
