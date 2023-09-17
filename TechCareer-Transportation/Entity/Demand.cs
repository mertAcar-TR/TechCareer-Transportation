using System;
namespace BlogApp.Entity
{
	public class Demand
	{
		public int DemandId { get; set; }
		public string? Text { get; set; }
		public DateTime DemandTime { get; set; }

		public int CompanyId { get; set; }
		public Company? Company { get; set; }

		public int UserId { get; set; }
		public User? User { get; set; } 
	}
}

