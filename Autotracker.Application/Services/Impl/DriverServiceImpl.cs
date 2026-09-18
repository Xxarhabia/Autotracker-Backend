using Autotracker.Application.Common;
using Autotracker.Application.Dtos;
using Autotracker.Application.Dtos.Drivers;
using Autotracker.Application.Dtos.Vehicles;
using Autotracker.Application.Interfaces;
using Autotracker.Domain.Builders;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services.Impl
{
    public class DriverServiceImpl : IDriverService
    {

        private readonly IDriverRepository _driverRepository;
        private readonly IVehicleRespository _vehicleRepository;

        public DriverServiceImpl(IDriverRepository driverRepository, IVehicleRespository vehicleRespository)
        {
            _driverRepository = driverRepository;
            _vehicleRepository = vehicleRespository;
        }

        public async Task<ServiceResult> CreateDriverAsync(CreateDriverRequestDto dto)
        {
            if (dto == null)
                return new ServiceResult(false, "Error al crear el conductor");

            if (await _driverRepository.ExistByDocumentAsync(dto.Document))
                return new ServiceResult(false, "El conductor ingresado ya existe");

            var driver = new DriverBuilder()
                .WithName(dto.Name)
                .WithDocument(dto.Document)
                .WithPhone(dto.Phone)
                .build();

            await _driverRepository.AddAsync(driver);

            var responseData = new DriverResponse
            {
                Id = driver.Id,
                Name = driver.Name,
                Document = driver.Document,
                Phone = driver.Phone
            };

            return new ServiceResult(true, "Conductor creado con exito", responseData);
        }

        public async Task<ServiceResult> ListDriversAsync()
        {
            List<DriverListDto> drivers = await _driverRepository.GetAllAsync();

            if (drivers.Count() == 0)
                return new ServiceResult(false, "No hay conductores registrados");

            return new ServiceResult(true, "Listado de conductores", drivers);
        }

        public async Task<ServiceResult> SearchDriverAsync(string document)
        {
            DriverListDto? driver = await _driverRepository.GetByDocumentAsync(document);

            if (driver == null)
                return new ServiceResult(false, "El conductor no existe");

            return new ServiceResult(true, "Conductor encontrado", driver);
        }

        public async Task<ServiceResult> AssignVehicleAsync(string document, string plate)
        {
            Driver? driver = await _driverRepository.GetDriverByDocumentAsync(document);
            if (driver == null)
                return new ServiceResult(false, $"No se encontro el conducor: {document}");

            Vehicle? vehicle = await _vehicleRepository.GetByPlateAsync(plate);
            if (vehicle == null)
                return new ServiceResult(false, $"no se encontro el vehiculo: {vehicle}");

            bool isAssigned = await _driverRepository.IsVehicleAssignedToAnotherDriverAsync(vehicle.Id, driver.Id);
            if (isAssigned)
                return new ServiceResult(false, "Este vehiculo ya esta asignado a otro conductor");

            driver.AssignVehicle(vehicle);

            await _driverRepository.UpdateAsync(driver);

            return new ServiceResult(true, "Vehiculo asignado al conductor", driver);
        }

        public async Task<ServiceResult> UnassignVehicleAsync(string document)
        {
            Driver? driver = await _driverRepository.GetDriverByDocumentAsync(document);
            if (driver == null)
                return new ServiceResult(false, $"No se encontró el conductor: {document}");

            driver.UnassignVehicle();
            await _driverRepository.UpdateAsync(driver);

            return new ServiceResult(true, "Vehiculo retirado del conductor", driver);

        }
    }
}
