using Autotracker.Application.Common;
using Autotracker.Application.Dtos;
using Autotracker.Application.Dtos.Drivers;
using Autotracker.Application.Interfaces;
using Autotracker.Domain.Builders;

namespace Autotracker.Application.Services.Impl
{
    public class DriverServiceImpl : IDriverService
    {

        private readonly IDriverRepository _repository;

        public DriverServiceImpl(IDriverRepository driverRepository) 
        {
            _repository = driverRepository;
        }

        public async Task<ServiceResult> CreateDriverAsync(CreateDriverRequestDto dto)
        {
            if (dto == null)
                return new ServiceResult(false, "Error al crear el conductor");

            if (await _repository.ExistByDocumentAsync(dto.Document))
                return new ServiceResult(false, "El conductor ingresado ya existe");

            var driver = new DriverBuilder()
                .WithName(dto.Name)
                .WithDocument(dto.Document)
                .WithPhone(dto.Phone)
                .build();

            await _repository.AddAsync(driver);

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
            List<DriverListDto> drivers = await _repository.GetAllAsync();

            if (drivers.Count() == 0)
                return new ServiceResult(false, "No hay conductores registrados");

            return new ServiceResult(true, "Listado de conductores", drivers);
        }

        public async Task<ServiceResult> SearchDriverAsync(string document)
        {
            DriverListDto? driver = await _repository.GetByDocumentAsync(document);

            if (driver == null)
                return new ServiceResult(false, "El conductor no existe");

            return new ServiceResult(true, "Conductor encontrado", driver);
        }
    }
}
