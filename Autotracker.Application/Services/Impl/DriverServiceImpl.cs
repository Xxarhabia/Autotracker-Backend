using Autotracker.Application.Common;
using Autotracker.Application.Interfaces;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services.Impl
{
    public class DriverServiceImpl : IDriverService
    {

        private readonly IDriverRepository _repository;

        public DriverServiceImpl(IDriverRepository driverRepository) 
        {
            _repository = driverRepository;
        }

        public async Task<ServiceResult> CreateDriverAsync(Driver driver)
        {
            if (driver == null)
                return new ServiceResult(false, "Error al crear el conductor");

            if (await _repository.ExistByDocumentAsync(driver.Document))
                return new ServiceResult(false, "El conductor ingresado ya existe");

            await _repository.AddAsync(driver);
            return new ServiceResult(true, "Conductor creado con exito", driver);
        }

        public async Task<ServiceResult> ListDriversAsync()
        {
            List<Driver> drivers = await _repository.GetAllAsync();

            if (drivers.Count() == 0)
                return new ServiceResult(false, "No hay conductores registrados");

            return new ServiceResult(true, "Listado de conductores", drivers);
        }

        public async Task<ServiceResult> SearchDriverAsync(string document)
        {
            Driver? driver = await _repository.GetByDocumentAsync(document);

            if (driver == null)
                return new ServiceResult(false, "El conductor no existe");

            return new ServiceResult(true, "Conductor encontrado", driver);
        }
    }
}
