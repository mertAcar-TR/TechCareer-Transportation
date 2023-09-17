using System;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
	public interface IWorkerRepository
	{
        IQueryable<Worker> Workers { get; }
        void CreateWorker(Worker worker);
    }
}

