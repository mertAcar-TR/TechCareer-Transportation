using System;
namespace BlogApp.Entity
{
	public class Company
	{
		public int CompanyId { get; set; }
		public string? CompanyName { get; set; }
		public string? Url { get; set; }
		public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
		public List<Comment> Comments { get; set; } = new List<Comment>();
		public int UserId { get; set; }
		public User User { get; set; }
		public List<Demand> Demands { get; set; } = new List<Demand>();
	}
}

