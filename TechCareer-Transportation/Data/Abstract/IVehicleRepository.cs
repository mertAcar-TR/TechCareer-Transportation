using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IVehicleRepository
    {
        IQueryable<Vehicle> Vehicles { get; }
        void CreateVehicle(Vehicle vehicle);
    }
}