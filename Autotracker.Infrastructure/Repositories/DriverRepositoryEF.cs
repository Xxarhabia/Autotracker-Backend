using Autotracker.Application.Dtos.Drivers;
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

        public async Task<List<DriverListDto>> GetAllAsync()
        {
            return await _context.Drivers
                .Select(d => new DriverListDto 
                {
                    Id = d.Id,
                    Document = d.Document,
                    FullName = d.Name,
                    VehiclePlate = d.Vehicle != null ? d.Vehicle.Plate : null,
                })
                .ToListAsync();
        }

        public async Task<DriverListDto?> GetByDocumentAsync(string document)
        {
            return await _context.Drivers
                .Where(d => d.Document == document)
                .Select(d => new DriverListDto
                {
                    Id = d.Id,
                    Document = d.Document,
                    FullName = d.Name,
                    VehiclePlate = d.Vehicle != null ? d.Vehicle.Plate : null
                })
                .FirstOrDefaultAsync();
        }

        public async Task<Driver?> GetDriverByDocumentAsync(string document)
        {
            return await _context.Drivers
                .Include(d => d.VehicleId)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> IsVehicleAssignedToAnotherDriverAsync(int vehicleId, int currentDriverId)
        {
            return await _context.Drivers
                .AnyAsync(d => d.VehicleId == vehicleId && d.Id != currentDriverId);
        }

        public async Task UpdateAsync(Driver driver)
        {
            await _context.SaveChangesAsync();
        }
    }
}
