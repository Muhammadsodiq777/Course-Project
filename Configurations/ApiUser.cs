using Microsoft.AspNetCore.Identity;

namespace Course_Project.Configurations;
    public class ApiUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
