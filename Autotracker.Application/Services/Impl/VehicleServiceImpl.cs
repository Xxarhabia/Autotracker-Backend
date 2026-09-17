using Autotracker.Application.Common;
using Autotracker.Application.Dtos.Vehicles;
using Autotracker.Application.Interfaces;
using Autotracker.Domain.Entities;
using Autotracker.Domain.Builders;
using Autotracker.Application.Dtos.Locations;

namespace Autotracker.Application.Services.Impl
{
    public class VehicleServiceImpl : IVehicleService
    {
        private readonly IVehicleRespository _respository;

        public VehicleServiceImpl(IVehicleRespository respository)
        {
            _respository = respository;
        }

        public async Task<ServiceResult> RegisterVehicleAsync(CreateVehicleDto dto)
        {
            if (dto == null)
                return new ServiceResult(false, "Error al registrar el vehiculo");

            if (await _respository.ExistsByPlateAsync(dto.Plate))
                return new ServiceResult(false, "Ya existe un vehiculo con esta placa");

            var vehicle = new VehicleBuilder()
                .WithPlate(dto.Plate)
                .WithBrand(dto.Brand)
                .WithModel(dto.Model)
                .WithYear(dto.Year)
                .WithEngineOn(false)
                .WithLocked(false)
                .WithInmovilized(false)
                .WithInitialLocation(8.2376, -73.3560, DateTime.Now) //Todo hacerlo dinamico luego
                .build();

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

        public async Task<ServiceResult> LockVehicleAsync(string plate)
        {
            Vehicle? vehicle = await _respository.GetByPlateAsync(plate);

            if (vehicle == null)
                return new ServiceResult(false, "Vehiculo no encontrado");

            string message = vehicle.Lock();
            await _respository.UpdateAsync(vehicle);

            return new ServiceResult(true, message, vehicle);
        }

        public async Task<ServiceResult> UnlockVehicleAsync(string plate)
        {
            Vehicle? vehicle = await _respository.GetByPlateAsync(plate);

            if (vehicle == null)
                return new ServiceResult(false, "Vehiculo no encontrado");

            string message = vehicle.Unlock();
            await _respository.UpdateAsync(vehicle);

            return new ServiceResult(true, message, vehicle);
        }

        public async Task<ServiceResult> StartVehicleAsync(string plate)
        {
            Vehicle? vehicle = await _respository.GetByPlateAsync(plate);

            if (vehicle == null)
                return new ServiceResult(false, "Vehiculo no encontrado");

            string message = vehicle.StartEngine();
            await _respository.UpdateAsync(vehicle);

            return new ServiceResult(true, message, vehicle);
        }

        public async Task<ServiceResult> StopVehicleAsync(string plate)
        {
            Vehicle? vehicle = await _respository.GetByPlateAsync(plate);

            if (vehicle == null)
                return new ServiceResult(false, "Vehiculo no encontrado");

            string message = vehicle.StopEngine();
            await _respository.UpdateAsync(vehicle);

            return new ServiceResult(true, message, vehicle);
        }

        public Task<ServiceResult> UpdateVehicleLocationAsync(string plate, LocationDto newLocationDto)
        {
            throw new NotImplementedException();
        }
    }
}
