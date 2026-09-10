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

        public void Add(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public bool ExistsByPlate(string plate)
        {
            return _context.Vehicles.Any(v => v.Plate == plate);
        }

        public List<Vehicle> GetAll()
        {
            return _context.Vehicles
                .Include(v => v.LocationHistory)
                .ToList();
        }

        public Vehicle? GetByPlate(string plate)
        {
            return _context.Vehicles
                .Include(v => v.LocationHistory)
                .FirstOrDefault(v => v.Plate == plate);
        }

        public void Update(Vehicle vehicle)
        {
            _context.Update(vehicle);
            _context.SaveChanges();
        }
    }
}