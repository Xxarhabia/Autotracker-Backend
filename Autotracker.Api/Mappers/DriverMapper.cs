using Autotracker.Api.Dtos.Driver;
using Autotracker.Domain.Entities;

namespace Autotracker.Api.Mappers
{
    public class DriverMapper
    {
        public static DriverDto ToDto(Driver driver)
        {
            return new DriverDto(
                driver.Name,
                driver.Document,
                driver.Phone,
                driver.VehicleId
            );
        }
    }
}
