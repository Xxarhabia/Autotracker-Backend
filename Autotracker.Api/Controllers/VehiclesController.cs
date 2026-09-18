using Autotracker.Application.Dtos.Vehicles;
using Autotracker.Api.Mappers;
using Autotracker.Application.Common;
using Autotracker.Application.Services;
using Autotracker.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Autotracker.Application.Dtos.Locations;

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
            var result = await _vehicleService.RegisterVehicleAsync(dto);

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

        [HttpPatch("start/{plate}")]
        public async Task<ActionResult> Start(string plate)
        {
            ServiceResult result = await _vehicleService.StartVehicleAsync(plate);
            return Ok(result.Message);
        }

        [HttpPatch("stop/{plate}")]
        public async Task<ActionResult> Stop(string plate)
        {
            ServiceResult result = await _vehicleService.StopVehicleAsync(plate);
            return Ok(result.Message);
        }

        [HttpPatch("lock/{plate}")]
        public async Task<ActionResult> Lock(string plate)
        {
            ServiceResult result = await _vehicleService.LockVehicleAsync(plate);
            return Ok(result.Message);
        }

        [HttpPatch("unlock/{plate}")]
        public async Task<ActionResult> Unlock(string plate)
        {
            ServiceResult result = await _vehicleService.UnlockVehicleAsync(plate);
            return Ok(result.Message);
        }

        [HttpPatch("location/{plate}")]
        public async Task<ActionResult> UpdateLocation(string plate, [FromBody] LocationDto dto)
        {
            ServiceResult result = await _vehicleService.UpdateVehicleLocationAsync(plate, dto);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
