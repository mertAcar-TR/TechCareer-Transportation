using System;
namespace BlogApp.Entity
{
	public class Job
	{
		public int JobId { get; set; }
		public string? JobName { get; set; }

		public List<Worker> Workers { get; set; } = new List<Worker>();
	}
}

