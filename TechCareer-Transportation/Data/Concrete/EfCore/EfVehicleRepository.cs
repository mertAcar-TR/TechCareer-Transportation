using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class EfVehicleRepository :IVehicleRepository
    {
        private TransportContext _context;
        public EfVehicleRepository(TransportContext context)
        {
            _context = context;
        }

        public IQueryable<Vehicle> Vehicles => _context.Vehicles;

        public void CreateVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }
    }
}