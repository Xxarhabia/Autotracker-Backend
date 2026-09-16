using Autotracker.Api.Dtos.Driver;
using Autotracker.Api.Dtos.Driver.Request;
using Autotracker.Application.Common;
using Autotracker.Application.Services;
using Autotracker.Domain.Builders;
using Microsoft.AspNetCore.Mvc;

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

            var driver = new DriverBuilder()
                .WithName(dto.Name)
                .WithDocument(dto.Document)
                .WithPhone(dto.Phone)
                .build();

            var response = await _driverService.CreateDriverAsync(driver);

            if (!response.Success)
                return BadRequest(response.Message);

            return CreatedAtAction(nameof(GetByDocument), new { document = dto.Document }, driver);
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
        
    }
}
