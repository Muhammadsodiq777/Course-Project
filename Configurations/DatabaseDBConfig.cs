using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Course_Project.Configurations;

public class DatabaseDBConfig : IdentityDbContext<ApiUser>
{
    public DatabaseDBConfig(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder builder)
    {

    }

}
