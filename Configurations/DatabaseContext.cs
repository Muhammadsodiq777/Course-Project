using Course_Project.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Course_Project.Configurations.DAO.Loaders;


namespace Course_Project.Configurations;

public class DatabaseContext : IdentityDbContext<ApiUser>
{
    public DatabaseContext(DbContextOptions options) : base(options)
    { }
    //public DbSet<UserEntity> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new UserConfigs());
    }

}
