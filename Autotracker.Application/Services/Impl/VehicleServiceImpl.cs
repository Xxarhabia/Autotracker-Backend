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

        public async Task<ServiceResult> RegisterVehicleAsync(Vehicle vehicle)
        {
            if (vehicle == null)
                return new ServiceResult(false, "Error al registrar el vehiculo");

            if (await _respository.ExistsByPlateAsync(vehicle.Plate))
                return new ServiceResult(false, "Ya existe un vehiculo con esta placa");

            await _respository.AddAsync(vehicle);
            return new ServiceResult(true, "Vehiculo registrado con exito", vehicle);
        }

        public async Task<ServiceResult> ListVehiclesAsync()
        {
            List<Vehicle> vehicles = await _respository.GetAllAsync();

            if (vehicles.Count() == 0) 
                return new ServiceResult(true, "No hay vehiculos registrados");

            return new ServiceResult(true, "Listado de vehiculos", vehicles);
        }

        public async Task<ServiceResult> SerchVehicleAsync(string plate)
        {
            Vehicle? vehicle =await _respository.GetByPlateAsync(plate);

            if (vehicle == null)
                return new ServiceResult(false, "El vehiculo no existe");

            return new ServiceResult(true, "Vehiculo encontrado", vehicle);
        }
    }
}
