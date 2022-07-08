using System.ComponentModel.DataAnnotations;

namespace Course_Project.Models
{
    public class LoginUserDTO
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 8)]
        public string PasswordHash { get; set; }
    }
    public class UserDTO : LoginUserDTO
    {
        [Required]

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool UserStatus { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public ICollection<string> Roles { get; set; }  
    }
}
