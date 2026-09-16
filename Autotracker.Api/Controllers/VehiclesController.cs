using Autotracker.Api.Dtos.Vehicle;
using Autotracker.Api.Dtos.Vehicle.Request;
using Autotracker.Api.Mappers;
using Autotracker.Application.Common;
using Autotracker.Application.Services;
using Autotracker.Domain.Builders;
using Autotracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Autotracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehiclesController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;

        public VehiclesController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpPost]
        public async Task<ActionResult<VehicleDto>> Register([FromBody] CreateVehicleDto dto)
        {
            var initialLocation = new Location(8.2376, -73.3560, DateTime.Now);

            var vehicle = new VehicleBuilder()
                .WithPlate(dto.Plate)
                .WithBrand(dto.Brand)
                .WithModel(dto.Model)
                .WithYear(dto.Year)
                .WithEngineOn(false)
                .WithLocked(false)
                .WithInmovilized(false)
                .WithInitialLocation(initialLocation)
                .build();

            var result = await _vehicleService.RegisterVehicleAsync(vehicle);

            if (!result.Success)
                return BadRequest(result.Message);

            var vehicleDto = VehicleMapper.ToDto((Vehicle)result.Data!);

            return CreatedAtAction(nameof(GetByPlate), new { plate = dto.Plate }, vehicleDto);
        }

        [HttpGet("{plate}")]
        public async Task<ActionResult<VehicleDto>> GetByPlate(string plate)
        {
            ServiceResult result = await _vehicleService.SerchVehicleAsync(plate);

            if (!result.Success)
                return NotFound(result.Message);

            Vehicle vehicle = (Vehicle)result.Data!;

            VehicleDto dto = VehicleMapper.ToDto(vehicle);

            return Ok(dto);
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleDto>>> GetAll()
        {
            ServiceResult result = await _vehicleService.ListVehiclesAsync();

            if (!result.Success)
                return NotFound(result.Message);

            List<Vehicle> vehicles = (List<Vehicle>)result.Data;

            List<VehicleDto> dtos = vehicles.Select(VehicleMapper.ToDto).ToList();

            return Ok(dtos);
        }
    }
}
