namespace Project1;
using Microsoft.EntityFrameworkCore;
using Project1.Models;

public class UserContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public UserContext(DbContextOptions option) : base(option) {}
}