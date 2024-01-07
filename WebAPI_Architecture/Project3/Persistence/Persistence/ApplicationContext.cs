using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence;

public class ApplicationContext : DbContext
{
     public DbSet<User> Users => Set<User>();

     public ApplicationContext(DbContextOptions options) : base(options)
     {
          Database.EnsureCreated();
     }
}