using System;
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
    public class EfDemandRepository : IDemandRepository
    {
        private TransportContext _context;
        public EfDemandRepository(TransportContext context)
        {
            _context = context;
        }
        public IQueryable<Demand> Demands => _context.Demands;

        public void CreateDemand(Demand demand)
        {
            _context.Demands.Add(demand);
            _context.SaveChanges();
        }
    }
}

