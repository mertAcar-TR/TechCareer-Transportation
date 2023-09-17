using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.Entity;

namespace BlogApp.Data.Concrete
{
    public class EfJobRepository:IJobRepository 
    {
        private TransportContext _context;
        public EfJobRepository(TransportContext context)
        {
            _context = context;
        }

        public IQueryable<Job> Jobs => _context.Jobs;

        public void CreateJob(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
        }
    }
}