using Autotracker.Application.Common;
using Autotracker.Domain.Entities;

namespace Autotracker.Application.Services
{
    public interface IDriverService
    {
        public Task<ServiceResult> CreateDriverAsync(Driver driver);
        public Task<ServiceResult> ListDriversAsync();
        public Task<ServiceResult> SearchDriverAsync(string document);
    }
}
