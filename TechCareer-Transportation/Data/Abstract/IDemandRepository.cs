using System;
using BlogApp.Entity;

namespace BlogApp.Data.Abstract
{
	public interface IDemandRepository
	{
        IQueryable<Demand> Demands { get; }
        void CreateDemand(Demand demand);
    }
}

