using System;
namespace BlogApp.Entity
{
	public class Worker
	{
		public int WorkerId { get; set; }
        public string? WorkerName { get; set; }

        public int JobId { get; set; }
		public Job? Job { get; set; } = null!;

		public int VehicleId { get; set; }
		public Vehicle? Vehicle { get; set; }
	}
}

