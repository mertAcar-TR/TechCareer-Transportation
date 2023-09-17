using System;
namespace BlogApp.Entity
{
	public class Vehicle
	{
		public int VehicleId { get; set; }
		public string? VehicleType { get; set; }
		public string? EnergySource { get; set; }
		public string? CountOfWheel { get; set; }
		public string? Brand { get; set; }

		public List<Worker>? Workers { get; set; } = new List<Worker>();

		public int CompanyId { get; set; }
		public Company? Company { get; set; }
	}
}

