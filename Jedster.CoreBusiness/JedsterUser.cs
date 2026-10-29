using Microsoft.AspNetCore.Identity;

namespace Jedster.CoreBusiness;

public class JedsterUser : IdentityUser 
{
    public string? Username { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    public Teacher? Teacher { get; set; }
    public int TeacherId { get; set; }
}