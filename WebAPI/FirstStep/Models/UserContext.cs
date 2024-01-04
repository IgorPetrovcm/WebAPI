namespace FirstStep.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

public class UserContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserContext(DbContextOptions<UserContext> option) : base(option) {}
}