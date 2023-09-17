using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class TransportContext:DbContext
    {
        public TransportContext(DbContextOptions<TransportContext> options): base(options) 
        {

        }
        public DbSet<Job> Jobs =>  Set<Job>();
        public DbSet<Worker> Workers =>  Set<Worker>();
        public DbSet<Vehicle> Vehicles =>  Set<Vehicle>();
        public DbSet<Company> Companies =>  Set<Company>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Comment> Comments => Set<Comment>();
        public DbSet<Demand> Demands => Set<Demand>();
    }
}