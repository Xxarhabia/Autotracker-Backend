using Autotracker.Domain.Entities;

namespace Autotracker.Application.Interfaces
{
    public interface IVehicleRespository
    {
        Vehicle? GetByPlate(string plate);
        List<Vehicle> GetAll();
        void Add(Vehicle vehicle);
        void Update(Vehicle vehicle);
        bool ExistsByPlate(string plate);
    }
}
