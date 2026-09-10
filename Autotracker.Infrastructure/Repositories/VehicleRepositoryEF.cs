// Autotraker.Infrastructure/Repositories/VehicleRepositoryEf.cs
using Autotracker.Domain.Entities;
using Autotracker.Infrastructure.Data;
using Autotracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Autotracker.Infrastructure.Repositories
{
    public class VehicleRepositoryEf : IVehicleRespository
    {
        private readonly AppDbContext _context;

        public VehicleRepositoryEf(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Vehicle vehicle)
        {
            await _context.Vehicles.AddAsync(vehicle);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByPlateAsync(string plate)
        {
            return await _context.Vehicles.AnyAsync(v => v.Plate == plate);
        }

        public async Task<List<Vehicle>> GetAllAsync()
        {
            return await _context.Vehicles
                .Include(v => v.LocationHistory)
                .ToListAsync();
        }

        public async Task<Vehicle?> GetByPlateAsync(string plate)
        {
            return await _context.Vehicles
                .Include(v => v.LocationHistory)
                .FirstOrDefaultAsync(v => v.Plate == plate);
        }

        public async Task UpdateAsync(Vehicle vehicle)
        {
            await _context.SaveChangesAsync();
        }
    }
}