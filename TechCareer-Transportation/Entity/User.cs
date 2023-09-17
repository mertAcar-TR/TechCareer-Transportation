namespace BlogApp.Entity;
public class User
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Image { get; set; }
    public List<Company> Companies { get; set; } = new List<Company>();
    public List<Comment> Comments { get; set; } = new List<Comment>();
    public List<Demand> Demands { get; set; } = new List<Demand>();
}
