using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
    public interface IJobRepository
    {
        IQueryable<Job> Jobs { get; }
        void CreateJob(Job job);
    }
}