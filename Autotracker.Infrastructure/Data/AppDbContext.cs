using Autotracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Autotracker.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Driver> Drivers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Vehicle
            modelBuilder.Entity<Vehicle>()
                .HasKey(v => v.Id);

            modelBuilder.Entity<Vehicle>()
                .HasIndex(v => v.Plate)
                .IsUnique();

            // Vehicle --> Location History
            modelBuilder.Entity<Vehicle>()
                .HasMany(v => v.LocationHistory)
                .WithOne(l => l.Vehicle)
                .HasForeignKey(l => l.VehicleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Driver --> Vehicle
            modelBuilder.Entity<Driver>()
                .HasOne(d => d.Vehicle)
                .WithOne()
                .HasForeignKey<Driver>(d => d.VehicleId)
                .OnDelete(DeleteBehavior.SetNull);

            // Location
            modelBuilder.Entity<Location>()
                .HasKey(l => l.Id);

            // Driver
            modelBuilder.Entity<Driver>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Driver>()
                .HasIndex(d => d.Document)
                .IsUnique();
        }
    }
}