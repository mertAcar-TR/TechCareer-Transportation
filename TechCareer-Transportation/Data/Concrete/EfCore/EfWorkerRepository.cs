using System;
using BlogApp.Data.Abstract;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete.EfCore
{
	public class EfWorkerRepository:IWorkerRepository
	{
        private TransportContext _context;
        public EfWorkerRepository(TransportContext context)
        {
            _context = context;
        }

        public IQueryable<Worker> Workers => _context.Workers;

        public void CreateWorker(Worker worker)
        {
            _context.Workers.Add(worker);
            _context.SaveChanges();
        }
    }
}

