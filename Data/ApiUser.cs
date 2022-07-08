using Microsoft.AspNetCore.Identity;

namespace Course_Project.Data;
    public class ApiUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool UserStatus { get; set; } = true;
}

