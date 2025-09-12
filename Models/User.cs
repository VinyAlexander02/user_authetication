using Microsoft.AspNetCore.Identity;

namespace user_auth.Models;

public class User : IdentityUser
{
    public DateTime BornDate { get; set; }

    public User() : base() { }
    
}