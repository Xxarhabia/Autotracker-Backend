using Autotracker.Application.Common;
using Autotracker.Application.Dtos.Drivers;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services
{
    public interface IDriverService
    {
        public Task<ServiceResult> CreateDriverAsync(CreateDriverRequestDto dto);
        public Task<ServiceResult> ListDriversAsync();
        public Task<ServiceResult> SearchDriverAsync(string document);
    }
}
