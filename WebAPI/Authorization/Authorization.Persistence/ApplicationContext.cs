namespace Authorization.Persistence;

using Microsoft.EntityFrameworkCore;
using Authorization.Domain;


public class ApplicationContext : DbContext
{
    public DbSet<User> users => Set<User>();

    public ApplicationContext(DbContextOptions options) : base(options)
    {
        
    }
}