using Autotracker.Api.Dtos.Driver;
using Autotracker.Api.Dtos.Driver.Request;
using Autotracker.Application.Common;
using Autotracker.Application.Services;
using Autotracker.Domain.Builders;
using Autotracker.Domain.Entities;
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

        //TODO crear mappers de toDto para la respuesta en cada endpoint
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

            Driver driver = (Driver)result.Data!;

            return Ok(driver);
        }
        
    }
}
