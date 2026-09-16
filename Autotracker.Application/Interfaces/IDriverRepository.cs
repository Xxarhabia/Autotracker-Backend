using Autotracker.Domain.Entities;

namespace Autotracker.Application.Interfaces
{
    public interface IDriverRepository
    {
        Task<Driver?> GetByDocumentAsync(string document);
        Task<bool> ExistByDocumentAsync(string document);
        Task<List<Driver>> GetAllAsync();
        Task AddAsync(Driver driver);
    }
}
