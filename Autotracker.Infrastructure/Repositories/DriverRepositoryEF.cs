using Autotracker.Application.Interfaces;
using Autotracker.Domain.Entities;
using Autotracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Autotracker.Infrastructure.Repositories
{
    public class DriverRepositoryEF : IDriverRepository
    {
        private readonly AppDbContext _context;

        public DriverRepositoryEF(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Driver driver)
        {
            await _context.Drivers.AddAsync(driver);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistByDocumentAsync(string document)
        {
            return await _context.Drivers.AnyAsync(d => d.Document == document);
        }

        public async Task<List<Driver>> GetAllAsync()
        {
            return await _context.Drivers
                .Include(d => d.VehicleId)
                .ToListAsync();
        }

        public async Task<Driver?> GetByDocumentAsync(string document)
        {
            return await _context.Drivers
                .Include(d => d.VehicleId)
                .FirstOrDefaultAsync(d => d.Document == document);
        }
    }
}
