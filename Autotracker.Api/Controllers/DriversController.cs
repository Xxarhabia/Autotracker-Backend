using Autotracker.Application.Common;
using Autotracker.Application.Services;
using Autotracker.Application.Dtos.Drivers;
using Microsoft.AspNetCore.Mvc;
using Autotracker.Api.Mappers;

namespace Autotracker.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriversController : ControllerBase
    {
        private readonly IDriverService _driverService;

        public DriversController(IDriverService driverService)
        {
            _driverService = driverService;
        }

        [HttpPost]
        public async Task<ActionResult<DriverDto>> Register(CreateDriverRequestDto dto)
        {
            var response = await _driverService.CreateDriverAsync(dto);

            if (!response.Success)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetByDocument), new { document = dto.Document }, response.Data);
        }

        [HttpGet("{document}")]
        public async Task<ActionResult<DriverDto>> GetByDocument(string document)
        {
            ServiceResult result = await _driverService.SearchDriverAsync(document);

            if (!result.Success) return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet]
        public async Task<ActionResult<List<DriverDto>>> GetAll()
        {
            ServiceResult result = await _driverService.ListDriversAsync();

            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPatch("{document}/assign/{palte}")]
        public async Task<ActionResult<DriverDto>> AssignVehicle(string document, string plate)
        {
            var result = await _driverService.AssignVehicleAsync(document, plate);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpPatch("{document}/unassign")]
        public async Task<ActionResult<DriverDto>> UnassgnVehicle(string document)
        {
            var result = await _driverService.UnassignVehicleAsync(document);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
        
    }
}
