using Autotracker.Api.Dtos.Vehicle;
using Autotracker.Api.Mappers;
using Autotracker.Application.Common;
using Autotracker.Application.Services;
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

        [HttpGet("{plate}")]
        public IActionResult GetByPlate(string plate)
        {
            ServiceResult result = _vehicleService.SerchVehicle(plate);

            if (!result.Success)
                return NotFound(result.Message);

            Vehicle vehicle = (Vehicle)result.Data!;

            VehicleDto dto = VehicleMapper.ToDto(vehicle);

            return Ok(dto);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            ServiceResult result = _vehicleService.ListVehicles();

            if (!result.Success)
                return NotFound(result.Message);

            List<Vehicle> vehicles = (List<Vehicle>)result.Data;

            List<VehicleDto> dtos = vehicles.Select(VehicleMapper.ToDto).ToList();

            return Ok(dtos);
        }
    }
}
