namespace Course_Project.Data;

public class UserEntity
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string  UserRole { get; set; }
    public bool UserStatus { get; set; }

}
